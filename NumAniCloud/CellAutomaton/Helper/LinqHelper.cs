using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CellAutomaton
{
	public static class LinqHelper
	{
		public static void ForEach<T>( this IEnumerable<T> source, Action<T> action )
		{
			foreach( var item in source )
				action( item );
		}

		public static void For<T>( this IEnumerable<T> source, Action<T, int> action )
		{
			int index = 0;
			foreach( var item in source )
			{
				action( item, index );
				++index;
			}
		}

		public static IEnumerable<T> DeleteNull<T>( this IEnumerable<T> source )
		{
			return source.Where( x => x != null );
		}

		public static IEnumerable<T> Repeat<T>( this IEnumerable<T> source, int num )
		{
			for( int i = 0; i < num; i++ )
			{
				foreach( var item in source )
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<T> GetRandom<T>( this IEnumerable<T> source, int num, Random machine = null )
		{
			if( source.Count() == 0 )
				return Enumerable.Empty<T>();
			if( machine == null )
				machine = new Random();

			var s = new List<T>( source );
			var result = new List<T>();
			for( int i = 0; i < num; i++ )
			{
				var x = s.GetRandom( machine );
				s.Remove( x );
				result.Add( x );
			}

			return result;
		}

		public static T GetRandom<T>( this IEnumerable<T> collection, Random machine = null )
		{
			if( collection.Count() == 0 ) return default( T );
			if( machine == null ) machine = new Random();
			return collection.ElementAt( machine.Next( collection.Count() ) );
		}

		public static int IndexOf<T>( this IEnumerable<T> collection, T value )
		{
			int i = 0;
			foreach( var item in collection )
			{
				if( item.Equals( value ) )
					break;
				++i;
			}
			return i;
		}
	}
}