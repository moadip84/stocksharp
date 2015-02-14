namespace StockSharp.Algo
{
	using System;
	using System.Data;
	using System.ServiceModel;

	/// <summary>
	/// ��������� ��� ������� � ������� �����.
	/// </summary>
	[ServiceContract(Namespace = "http://web.cbr.ru/")]
	public interface IDailyInfoSoap
	{
		/// <summary>
		/// �������� ����� ����� �� ������������ ����.
		/// </summary>
		/// <param name="date">���� ������.</param>
		/// <returns>����� �����.</returns>
		[OperationContract(Action = "http://web.cbr.ru/GetCursOnDate", ReplyAction = "*")]
		[XmlSerializerFormat]
		DataSet GetCursOnDate([MessageParameter(Name = "On_date")]DateTime date);
	}
}