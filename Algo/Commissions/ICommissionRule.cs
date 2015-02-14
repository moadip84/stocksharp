namespace StockSharp.Algo.Commissions
{
	using Ecng.Serialization;

	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// ��������� ������� ���������� ��������.
	/// </summary>
	public interface ICommissionRule : IPersistable
	{
		/// <summary>
		/// ���������.
		/// </summary>
		string Title { get; }

		/// <summary>
		/// ��������� �������� ��������.
		/// </summary>
		decimal Commission { get; }

		/// <summary>
		/// �������� ��������.
		/// </summary>
		Unit Value { get; }

		/// <summary>
		/// �������� ���������.
		/// </summary>
		void Reset();

		/// <summary>
		/// ���������� ��������.
		/// </summary>
		/// <param name="message">���������, ���������� ���������� �� ������ ��� ����������� ������.</param>
		/// <returns>��������. ���� �������� ���������� ����������, �� ����� ���������� <see langword="null"/>.</returns>
		decimal? ProcessExecution(ExecutionMessage message);
	}
}