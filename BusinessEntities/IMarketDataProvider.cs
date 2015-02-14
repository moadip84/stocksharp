namespace StockSharp.BusinessEntities
{
	using System;
	using System.Collections.Generic;

	using StockSharp.Messages;

	/// <summary>
	/// ��������� ���������� ������-������ �� �����������.
	/// </summary>
	public interface IMarketDataProvider
	{
		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		event Action<Security, IEnumerable<KeyValuePair<Level1Fields, object>>, DateTimeOffset, DateTime> ValuesChanged;

		/// <summary>
		/// �������� ������ ���������.
		/// </summary>
		/// <param name="security">����������, �� �������� ����� �������� ������.</param>
		/// <returns>������ ���������.</returns>
		MarketDepth GetMarketDepth(Security security);

		/// <summary>
		/// �������� �������� ������-������ ��� �����������.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <param name="field">���� ������-������.</param>
		/// <returns>�������� ����. ���� ������ ���, �� ����� ���������� <see langword="null"/>.</returns>
		object GetSecurityValue(Security security, Level1Fields field);

		/// <summary>
		/// �������� ����� ��������� ����� <see cref="Level1Fields"/>, ��� ������� ���� ������-������ ��� �����������.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <returns>����� ��������� �����.</returns>
		IEnumerable<Level1Fields> GetLevel1Fields(Security security);
	}
}