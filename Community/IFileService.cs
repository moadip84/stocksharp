namespace StockSharp.Community
{
	using System;
	using System.ServiceModel;

	/// <summary>
	/// ���������, ����������� ������ ������ � ������� � �����������.
	/// </summary>
	[ServiceContract(Namespace = "http://stocksharp.com/services/fileservice.svc")]
	public interface IFileService
	{
		/// <summary>
		/// �������� �� ���� ����.
		/// </summary>
		/// <param name="sessionId">������������� ������.</param>
		/// <param name="fileName">��� �����.</param>
		/// <param name="body">���� �����.</param>
		/// <returns>������ �� ���������� ����.</returns>
		[OperationContract]
		string Upload(Guid sessionId, string fileName, byte[] body);
	}
}