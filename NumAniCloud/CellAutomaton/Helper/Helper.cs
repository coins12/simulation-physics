using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellAutomaton
{
	public static class Helper
	{
		public static Encoding sjis = Encoding.GetEncoding( "shift-jis" );

		/// <summary>
		/// int 型の値を符号付き数字の文字列に変換します。
		/// </summary>
		/// <param name="value">文字列に変換する値。</param>
		/// <returns>符号付き数字の文字列。</returns>
		public static string ToSignedString( this int value )
		{
			return value >= 0 ? ( "+" + value ) : value.ToString();
		}

		/// <summary>
		/// 等幅フォントを前提に、文字の幅を半角文字単位で測ります。
		/// </summary>
		/// <param name="c">幅を計る文字。</param>
		/// <returns>文字の幅。</returns>
		public static int GetWidth( char c )
		{
			return sjis.GetByteCount( c.ToString() );
		}
		/// <summary>
		/// 等幅フォントを前提に、文字列の幅を半角文字単位で測ります。
		/// </summary>
		/// <param name="str">幅を測る文字列。</param>
		/// <returns>文字列の幅。</returns>
		public static int GetWidth( string str )
		{
			return sjis.GetByteCount( str );
		}
		/// <summary>
		/// 等幅フォントを前提に、文字列を指定された幅まで切り取ります。
		/// </summary>
		/// <param name="str">切り取る文字列。</param>
		/// <param name="width">文字列から切り取る幅。</param>
		/// <returns>切り取られた文字列。文字列の幅より切り取る幅が長ければ、もとの文字列と一致します。</returns>
		public static string Substring( string str, int width )
		{
			if( str == "" )
				return "";

			var b = GetWidth( str[0] );

			if( b > width )
				return "";

			return str[0] + Substring( str.Substring( 1, str.Length - 1 ), width - b );
		}
		public static string PadRight( string str, int width )
		{
			if( GetWidth( str ) >= width )
				return str;
			return PadRight( str + " ", width );
		}

		/// <summary>
		/// 列挙体の値の個数を数えます。
		/// </summary>
		/// <typeparam name="T">値の個数を数える列挙型。</typeparam>
		/// <returns>列挙型の値の個数。</returns>
		public static int GetEnumLength<T>()
		{
			var type = typeof( T );
			if( !type.IsEnum )
			{
				throw new ArgumentException( "列挙型でない型が指定されました。" );
			}
			return Enum.GetValues( type ).Length;
		}
		/// <summary>
		/// 列挙型の値のシーケンスを返します。
		/// </summary>
		/// <typeparam name="T">列挙型。</typeparam>
		/// <returns>列挙型の値のシーケンス。</returns>
		public static IEnumerable<T> GetValues<T>()
		{
			var type = typeof( T );
			if( !type.IsEnum )
			{
				throw new ArgumentException( "列挙型でない型が指定されました。" );
			}
			return Enum.GetValues( type ).Cast<T>();
		}

		/// <summary>
		/// 値を指定した最小値と最大値の間に収まるように補正します。
		/// </summary>
		/// <typeparam name="T">補正する値の、IComparable を実装する型。</typeparam>
		/// <param name="value">補正する値。</param>
		/// <param name="min">最小値。</param>
		/// <param name="max">最大値。</param>
		/// <returns>補正した値。</returns>
		public static T Clamp<T>( T value, T min, T max ) where T : IComparable
		{
			if( min.CompareTo( max ) == 1 )
				throw new ArgumentException( "最小値が最大値より大きい値に設定されました。" );
			if( value.CompareTo( max ) == 1 )
				return max;
			else if( value.CompareTo( min ) == -1 )
				return min;
			else
				return value;
		}
		/// <summary>
		/// 値が指定した最小値と最大値の間にあるかどうか調べます。
		/// </summary>
		/// <typeparam name="T">調べる値の、IComparable を実装する型。</typeparam>
		/// <param name="value">調べる対象の値。</param>
		/// <param name="min">最小値。</param>
		/// <param name="max">最大値。</param>
		/// <returns>値が最小値と最大値の間にあるかどうかを表す真偽値。</returns>
		public static bool IsInside<T>( T value, T min, T max ) where T : IComparable
		{
			if( min.CompareTo( max ) == 1 )
				throw new ArgumentException( "最小値が最大値より大きい値に設定されました。" );
			return value.CompareTo( min ) != -1 && value.CompareTo( max ) != 1;
		}
		/// <summary>
		/// ２つの IComparable の値うち、小さい方を返します。
		/// </summary>
		/// <typeparam name="T">比較する値の、IComparable を実装する型。</typeparam>
		/// <param name="value1">比較する IComparable の最初の値。</param>
		/// <param name="value2">比較する IComparable の２番目の値。</param>
		/// <returns>小さい方の値。</returns>
		public static T Min<T>( T value1, T value2 ) where T : IComparable
		{
			return value1.CompareTo( value2 ) == -1 ? value1 : value2;
		}
		/// <summary>
		/// ２つの IComparable の値うち、大きい方を返します。
		/// </summary>
		/// <typeparam name="T">比較する値の、IComparable を実装する型。</typeparam>
		/// <param name="value1">比較する IComparable の最初の値。</param>
		/// <param name="value2">比較する IComparable の２番目の値。</param>
		/// <returns>大きい方の値。</returns>
		public static T Max<T>( T value1, T value2 ) where T : IComparable
		{
			return value1.CompareTo( value2 ) == 1 ? value1 : value2;
		}
		/// <summary>
		/// ２つの変数を入れ替えます。
		/// </summary>
		/// <typeparam name="Type">変数の型。</typeparam>
		/// <param name="obj1">２つめの変数と入れ替える変数。</param>
		/// <param name="obj2">１つめの変数と入れ替える変数。</param>
		public static void Swap<Type>( ref Type obj1, ref Type obj2 )
		{
			Type temp = obj1;
			obj1 = obj2;
			obj2 = obj1;
		}
	}
}
