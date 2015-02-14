namespace StockSharp.Algo.Commissions
{
	using StockSharp.BusinessEntities;

	/// <summary>
	/// �������� ���� (��������, ���������� ��� ���������).
	/// </summary>
	public interface ICommissionProfile
	{
		/// <summary>
		/// �������� ��������.
		/// </summary>
		/// <param name="trade">������.</param>
		/// <returns>��������.</returns>
		decimal GetCommission(MyTrade trade);

		/// <summary>
		/// �������� ��������.
		/// </summary>
		/// <param name="order">������.</param>
		/// <returns>��������.</returns>
		decimal GetCommission(Order order);
	}
}