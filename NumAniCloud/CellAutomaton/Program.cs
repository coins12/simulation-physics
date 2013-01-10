using System;
using System.Linq;

namespace CellAutomaton
{
	class Program
	{
		static void Example1()
		{
			Random random = new Random();
			var first = Enumerable.Repeat( 0, 20 ).ToArray();
			while( first.Count( _ => _ == 1 ) < Math.Floor( first.Length * 0.3 ) )
			{
				first[random.Next( 0, first.Length )] = 1;
			}

			CellAutomaton1D<int>.FromRule( 184 )
				.GetGenerations( first.ToArray() )
				.Take( 10 )
				.ForEach( _1 =>
				{
					_1.ForEach( _2 => Console.Write( " " + _2 ) );
					Console.WriteLine();
				} );
		}
		static void Example2()
		{
			char w = '□';
			char b = '■';
			char d = '・';
			var sample = new CellAutomaton1D<char>();
			sample.GetParentIndexes = i => new[] { i + 1, i - 1 };
			sample.Default = d;
			sample.AddRule( w, w, w );
			sample.AddRule( b, w, b );
			sample.AddRule( d, w, d );
			sample.AddRule( b, b, w );
			sample.AddRule( w, b, b );
			sample.AddRule( b, b, d );
			sample.AddRule( d, d, w );
			sample.AddRule( b, d, b );
			sample.AddRule( d, d, d );

			Console.WriteLine( "何かキーを押すと次の世代へ移行します。ただし q を押すと終了します。" );
			sample.GetGenerations( new[] { w, d, w, b, d, w, d, w, d, w, b, b, d, b, w, w, d, b }.Repeat( 2 ).ToArray() )
				.TakeWhile( _ => Console.ReadKey( true ).KeyChar != 'q' )
				.ForEach( _ =>
				{
					_.ForEach( Console.Write );
					Console.WriteLine();
				} );
			Console.WriteLine( "finish" );
		}

		static void Main( string[] args )
		{
			Example1();
			Console.ReadKey();
		}
	}
}
