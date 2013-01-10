using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellAutomaton
{
	public class CellAutomaton1D<TCell> where TCell : struct
	{
		public List<Tuple<TCell[], TCell>> Rules { get; set; }
		public Func<int, IEnumerable<int>> GetParentIndexes { get; set; }
		public TCell Default { get; set; }

		public CellAutomaton1D()
		{
			Rules = new List<Tuple<TCell[], TCell>>();
			Default = default( TCell );
		}
		public void AddRule( TCell next, params TCell[] prev )
		{
			var rule = new Tuple<TCell[], TCell>( prev, next );
			var t = Rules.FirstOrDefault( _ => _.Item1.SequenceEqual( prev ) );

			if( t != null )
			{
				Rules.Remove( t );
			}
			Rules.Add( rule );
		}

		public IEnumerable<TCell[]> GetGenerations( params TCell[] first )
		{
			TCell[] current = first;
			while( true )
			{
				yield return current;

				current = Enumerable.Range( 0, first.Length )
					.Select( _ => GetNext( current, _ ) )
					.ToArray();
			}
		}

		public TCell GetNext( TCell[] prev, int index )
		{
			if( GetParentIndexes == null )
				throw new InvalidOperationException( "GetParentIndexes が設定されていません。" );

			var parents = GetParentIndexes( index )
				.Select( _ => Helper.IsInside( _, 0, prev.Length - 1 ) ? prev[_] : Default );
			var rule = Rules.FirstOrDefault( _ => _.Item1.SequenceEqual( parents ) );

			if( rule == null )
			{
				var m = new StringBuilder();
				m.Append( "(" );
				parents.ForEach( _ => m.Append( _ + ", " ) );
				m.Append( ") を前の世代とする規則が設定されていません。" );
				throw new InvalidOperationException( m.ToString() );
			}
			else
			{
				return rule.Item2;
			}
		}

		public static CellAutomaton1D<int> FromRule( int ruleNo )
		{
			var automaton = new CellAutomaton1D<int>();
			automaton.Default = 0;
			automaton.GetParentIndexes = i => new[] { i - 1, i, i + 1 };

			Func<int, int, int> power = ( x, y ) =>
			{
				var result = 1;
				Enumerable.Range( 0, y )
					.ForEach( _ => result *= x );
				return result;
			};

			Enumerable.Range( 0, 8 )
				.ForEach( i => automaton.AddRule(
					ruleNo / power( 2, i ) % 2,
					i / 4 % 2,
					i / 2 % 2,
					i / 1 % 2 ) );

			return automaton;
		}
	}
}
