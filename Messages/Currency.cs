namespace StockSharp.Messages
{
	using System;
	using System.Runtime.Serialization;
	using NetDataContract = System.Runtime.Serialization.DataContractAttribute;

	using Ecng.Common;
	using Ecng.Serialization;

	/// <summary>
	/// ������.
	/// </summary>
	[NetDataContract]
	[Serializable]
	[Ignore(FieldName = "IsDisposed")]
	public class Currency : Equatable<Currency>
	{
		/// <summary>
		/// ������� ������ ������.
		/// </summary>
		public Currency()
		{
			Type = CurrencyTypes.RUB;
		}

		/// <summary>
		/// ��� ������. �� ���������, ����� �������� <see cref="CurrencyTypes.RUB"/>.
		/// </summary>
		[DataMember]
		public CurrencyTypes Type { get; set; }

		/// <summary>
		/// �������� � �������� <see cref="CurrencyTypes"/>.
		/// </summary>
		[DataMember]
		public decimal Value { get; set; }

		/// <summary>
		/// ������� ����� ������ (����������� ���������� ������).
		/// </summary>
		/// <returns>����� ������.</returns>
		public override Currency Clone()
		{
			return new Currency { Type = Type, Value = Value };
		}

		/// <summary>
		/// �������� �� ���������.
		/// </summary>
		/// <param name="other">������, � ������� ����� ��������.</param>
		/// <returns>��������� ���������.</returns>
		protected override bool OnEquals(Currency other)
		{
			return Type == other.Type && Value == other.Value;
		}

		/// <summary>
		/// ���������� ���-��� ������� <see cref="Currency"/>.
		/// </summary>
		/// <returns>���-���.</returns>
		public override int GetHashCode()
		{
			return Type.GetHashCode() ^ Value.GetHashCode();
		}

		/// <summary>
		/// �������� ��������� �������������.
		/// </summary>
		/// <returns>��������� �������������.</returns>
		public override string ToString()
		{
			return "{0} {1}".Put(Value, Type);
		}

		/// <summary>
		/// �������� <see cref="decimal"/> �������� � ������� <see cref="Currency"/>.
		/// </summary>
		/// <param name="value"><see cref="decimal"/> ��������.</param>
		/// <returns>������ <see cref="Currency"/>.</returns>
		public static implicit operator Currency(decimal value)
		{
			return new Currency { Value = value };
		}

		/// <summary>
		/// �������� ������ <see cref="Currency"/> � <see cref="decimal"/> ��������.
		/// </summary>
		/// <param name="unit">������ <see cref="Currency"/>.</param>
		/// <returns><see cref="decimal"/> ��������.</returns>
		public static explicit operator decimal(Currency unit)
		{
			if (unit == null)
				throw new ArgumentNullException("unit");

			return unit.Value;
		}

		/// <summary>
		/// ������� ��� ������� <see cref="Currency"/>.
		/// </summary>
		/// <remarks>
		/// �������� ������ ����� ���������� <see cref="Type"/>.
		/// </remarks>
		/// <param name="c1">������ ������ <see cref="Currency"/>.</param>
		/// <param name="c2">������ ������ <see cref="Currency"/>.</param>
		/// <returns>��������� ��������.</returns>
		public static Currency operator +(Currency c1, Currency c2)
		{
			if (c1 == null)
				throw new ArgumentNullException("c1");

			if (c2 == null)
				throw new ArgumentNullException("c2");

			return (decimal)c1 + (decimal)c2;
		}

		/// <summary>
		/// ������� ���� �������� �� ������ ��������.
		/// </summary>
		/// <param name="c1">������ ������ <see cref="Currency"/>.</param>
		/// <param name="c2">������ ������ <see cref="Currency"/>.</param>
		/// <returns>��������� ���������.</returns>
		public static Currency operator -(Currency c1, Currency c2)
		{
			if (c1 == null)
				throw new ArgumentNullException("c1");

			if (c2 == null)
				throw new ArgumentNullException("c2");

			return (decimal)c1 - (decimal)c2;
		}

		/// <summary>
		/// �������� ���� �������� �� ������.
		/// </summary>
		/// <param name="c1">������ ������ <see cref="Currency"/>.</param>
		/// <param name="c2">������ ������ <see cref="Currency"/>.</param>
		/// <returns>��������� ���������.</returns>
		public static Currency operator *(Currency c1, Currency c2)
		{
			if (c1 == null)
				throw new ArgumentNullException("c1");

			if (c2 == null)
				throw new ArgumentNullException("c2");

			return (decimal)c1 * (decimal)c2;
		}

		/// <summary>
		/// �������� ���� �������� �� ������.
		/// </summary>
		/// <param name="c1">������ ������ <see cref="Currency"/>.</param>
		/// <param name="c2">������ ������ <see cref="Currency"/>.</param>
		/// <returns>��������� �������.</returns>
		public static Currency operator /(Currency c1, Currency c2)
		{
			if (c1 == null)
				throw new ArgumentNullException("c1");

			if (c2 == null)
				throw new ArgumentNullException("c2");

			return (decimal)c1 / (decimal)c2;
		}
	}

	/// <summary>
	/// ��������������� ����� ��� ������ � <see cref="Currency"/>.
	/// </summary>
	public static class CurrencyHelper
	{
		/// <summary>
		/// �������� ������ ���� <see cref="Decimal"/> � ���� <see cref="Currency"/>.
		/// </summary>
		/// <param name="value">�������� ������.</param>
		/// <param name="type">��� ������.</param>
		/// <returns>������.</returns>
		public static Currency ToCurrency(this decimal value, CurrencyTypes type)
		{
			return new Currency { Type = type, Value = value };
		}
	}
}