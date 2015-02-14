namespace StockSharp.Algo.Commissions
{
	using Ecng.Collections;

	/// <summary>
	/// ��������� ��������� ������� ��������.
	/// </summary>
	public interface ICommissionManager : ICommissionRule
	{
		/// <summary>
		/// ������ ������ ���������� ��������.
		/// </summary>
		ISynchronizedCollection<ICommissionRule> Rules { get; }

		///// <summary>
		///// ��������� �������� ��������, ��������������� �� �����.
		///// </summary>
		//IDictionary<CommissionTypes, decimal> CommissionPerTypes { get; }
	}
}