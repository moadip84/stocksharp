namespace StockSharp.Algo.Commissions
{
	using System;
	using System.ServiceModel;

	/// <summary>
	/// ��������� � ������� ��������.
	/// </summary>
	[ServiceContract(Namespace = "http://stocksharp.com/services/commissionservice.svc")]
	public interface ICommissionService
	{
		/// <summary>
		/// �������� ������ �������� ��������.
		/// </summary>
		/// <param name="sessionId">������������ ������.</param>
		/// <returns>�������� ��������.</returns>
		[OperationContract]
		string[] GetNames(Guid sessionId);

		/// <summary>
		/// �������� ������� �������� �� �� ��������.
		/// </summary>
		/// <param name="sessionId">������������ ������.</param>
		/// <param name="name">�������� ��������.</param>
		/// <returns>������� ��������.</returns>
		[OperationContract]
		CommissionRule[] GetRules(Guid sessionId, string name);
	}
}