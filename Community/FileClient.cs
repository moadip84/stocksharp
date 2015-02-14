namespace StockSharp.Community
{
	using System;

	using Ecng.Common;

	/// <summary>
	/// ������ ��� ������� � ������� ������ � ������� � �����������.
	/// </summary>
	public class FileClient : BaseCommunityClient<IFileService>
	{
		/// <summary>
		/// ������� <see cref="FileClient"/>.
		/// </summary>
		public FileClient()
			: this("http://stocksharp.com/services/fileservice.svc".To<Uri>())
		{
		}

		/// <summary>
		/// ������� <see cref="FileClient"/>.
		/// </summary>
		/// <param name="address">����� �������.</param>
		public FileClient(Uri address)
			: base(address, "file")
		{
		}

		/// <summary>
		/// �������� �� ���� ����.
		/// </summary>
		/// <param name="fileName">��� �����.</param>
		/// <param name="body">���� �����.</param>
		/// <returns>������ �� ���������� ����.</returns>
		public string Upload(string fileName, byte[] body)
		{
			return Invoke(f => f.Upload(SessionId, fileName, body));
		}
	}
}