using System;
using System.Security.Cryptography;

namespace DataAccess.Helper
{
	public static class CryptographyHelperExtension
	{
		public static string ToSafeBase64(this string source)
		{
			return ToBase64(source).Replace('/', '-');
		}

		public static string ToSha512(this string source)
		{
			using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
			{
				byte[] hash = sha512.ComputeHash(System.Text.Encoding.Unicode.GetBytes(source));

				return BitConverter.ToString(hash).Replace("-", string.Empty);
			}
		}

		private static string ToBase64(this string source)
		{
			return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(source));
		}
	}
}