﻿using System;
using System.Text;

namespace SnowPakTool {

	public static class MiscHelpers {

		/// <summary>
		/// Encoding used for file names. Could be some other encoding entirely, could be a multi-byte one, but works so far.
		/// </summary>
		public static Encoding Encoding { get; } = Encoding.GetEncoding ( 437 , EncoderFallback.ExceptionFallback , DecoderFallback.ExceptionFallback );


		public static ushort EnsureFitsUInt16 ( int value ) {
			if ( value > ushort.MaxValue ) throw new ArgumentOutOfRangeException ( nameof ( value ) , $"Value exceeds {ushort.MaxValue}." );
			return (ushort) value;
		}

		public static int EnsureFitsInt32 ( long value ) {
			if ( value > int.MaxValue ) throw new ArgumentOutOfRangeException ( nameof ( value ) , $"Value exceeds {int.MaxValue}." );
			return (int) value;
		}

		public static ushort GetDosTime ( DateTime dateTime ) {
			return (ushort) (
				dateTime.Second / 2
				| dateTime.Minute << 5
				| dateTime.Hour << 11
			);
		}

		public static ushort GetDosDate ( DateTime dateTime ) {
			if ( dateTime.Year < 1980 || dateTime.Year >= 2108 ) return 0;
			return (ushort) (
				dateTime.Day
				| dateTime.Month << 5
				| ( dateTime.Year - 1980 ) << 9
			);
		}

		public static unsafe uint SizeOf<T> () where T : unmanaged {
			return (uint) sizeof ( T );
		}

		internal static void Assert ( bool value ) {
			if ( !value ) throw new InvalidOperationException ();
		}

	}

}
