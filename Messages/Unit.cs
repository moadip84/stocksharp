namespace StockSharp.Messages
{
	using System;
	using System.Linq;
	using System.Runtime.Serialization;

	using Ecng.Common;
	using Ecng.ComponentModel;
	using Ecng.Localization;
	using Ecng.Serialization;

	using StockSharp.Localization;

	/// <summary>
	/// ������� ���������.
	/// </summary>
	[Serializable]
	[System.Runtime.Serialization.DataContract]
	public enum UnitTypes
	{
		/// <summary>
		/// ���������� ��������. ��� ��������� ����� ��������� �����.
		/// </summary>
		[EnumMember]
		Absolute,

		/// <summary>
		/// ��������. ��� ��������� � ���� ����� ��������.
		/// </summary>
		[EnumMember]
		Percent,

		/// <summary>
		/// ����� ���� �����������.
		/// </summary>
		[EnumMember]
		Point,

		/// <summary>
		/// ��� ���� �����������.
		/// </summary>
		[EnumMember]
		Step,

		/// <summary>
		/// �������������� ��������. ������ ������� ��������� ��������� �������� ���������� �����,
		/// ������� �� ����� ���� ������������ � �������������� ��������� <see cref="Unit"/>.
		/// </summary>
		[EnumMember]
		Limit,
	}

	/// <summary>
	/// ����������� �����, ����������� �������� �������� � ����������, ����������, ��������� � �������� ���������.
	/// </summary>
	[Serializable]
	[System.Runtime.Serialization.DataContract]
	[Ignore(FieldName = "IsDisposed")]
	public class Unit : Equatable<Unit>, IOperable<Unit>
	{
		/// <summary>
		/// ������� ��������.
		/// </summary>
		public Unit()
		{
		}

		/// <summary>
		/// ������� ���������� �������� <see cref="UnitTypes.Absolute"/>.
		/// </summary>
		/// <param name="value">��������.</param>
		public Unit(decimal value)
			: this(value, UnitTypes.Absolute)
		{
		}

		/// <summary>
		/// ������� �������� ���� <see cref="UnitTypes.Absolute"/> ��� <see cref="UnitTypes.Percent"/>.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <param name="type">������� ���������.</param>
		public Unit(decimal value, UnitTypes type)
			: this(value, type, null)
		{
		}

		/// <summary>
		/// ������� �������� ���� <see cref="UnitTypes.Point"/> ��� <see cref="UnitTypes.Step"/>.
		/// </summary>
		/// <param name="value">��������.</param>
		/// <param name="type">������� ���������.</param>
		/// <param name="getTypeValue">����������, ������������ ��������, ��������������� � <see cref="Type"/> (��� ���� ��� ������).</param>
		public Unit(decimal value, UnitTypes type, Func<UnitTypes, decimal?> getTypeValue)
		{
			// mika ������ �������� ����� ������ ��� �������������� ���������
			//
			//if (type == UnitTypes.Point || type == UnitTypes.Step)
			//{
			//    if (security == null)
			//        throw new ArgumentException("������� ��������� �� ����� ���� '{0}' ��� ��� �� �������� ���������� �� �����������.".Put(type), "type");
			//}

			Value = value;
			Type = type;
			GetTypeValue = getTypeValue;
		}

		/// <summary>
		/// ������� ���������.
		/// </summary>
		[DataMember]
		public UnitTypes Type { get; set; }

		/// <summary>
		/// ��������.
		/// </summary>
		[DataMember]
		public decimal Value { get; set; }

		[field: NonSerialized]
		private Func<UnitTypes, decimal?> _getTypeValue;

		/// <summary>
		/// ����������, ������������ ��������, ��������������� � <see cref="Type"/> (��� ���� ��� ������).
		/// </summary>
		[Ignore]
		public Func<UnitTypes, decimal?> GetTypeValue
		{
			get { return _getTypeValue; }
			set { _getTypeValue = value; }
		}

		///<summary>
		/// ������� ����� ������� <see cref="Unit" />.
		///</summary>
		///<returns>�����.</returns>
		public override Unit Clone()
		{
			return new Unit
			{
				Type = Type,
				Value = Value,
				GetTypeValue = GetTypeValue,
			};
		}

		/// <summary>
		/// �������� �������� � ������.
		/// </summary>
		/// <param name="other">������ ��������, � ������� ���������� ����������.</param>
		/// <returns>��������� ��������� �������.</returns>
		public override int CompareTo(Unit other)
		{
			if (this == other)
				return 0;

			if (this < other)
				return -1;

			return 1;
		}

		/// <summary>
		/// �������� <see cref="decimal"/> �������� � ������� <see cref="Unit"/>.
		/// </summary>
		/// <param name="value"><see cref="decimal"/> ��������.</param>
		/// <returns>������ <see cref="Unit"/>.</returns>
		public static implicit operator Unit(decimal value)
		{
			return new Unit(value);
		}

		/// <summary>
		/// �������� <see cref="int"/> �������� � ������� <see cref="Unit"/>.
		/// </summary>
		/// <param name="value"><see cref="int"/> ��������.</param>
		/// <returns>������ <see cref="Unit"/>.</returns>
		public static implicit operator Unit(int value)
		{
			return new Unit(value);
		}

		/// <summary>
		/// �������� ������ <see cref="Unit"/> � <see cref="decimal"/> ��������.
		/// </summary>
		/// <param name="unit">������ <see cref="Unit"/>.</param>
		/// <returns><see cref="decimal"/> ��������.</returns>
		public static explicit operator decimal(Unit unit)
		{
			if (unit == null)
				throw new ArgumentNullException("unit");

			switch (unit.Type)
			{
				case UnitTypes.Limit:
				case UnitTypes.Absolute:
					return unit.Value;
				case UnitTypes.Percent:
					throw new ArgumentException(LocalizedStrings.PercentagesConvert, "unit");
				case UnitTypes.Point:
					return unit.Value * unit.SafeGetTypeValue(null);
				case UnitTypes.Step:
					return unit.Value * unit.SafeGetTypeValue(null);
				default:
					throw new ArgumentOutOfRangeException("unit");
			}
		}

		/// <summary>
		/// �������� <see cref="double"/> �������� � ������� <see cref="Unit"/>.
		/// </summary>
		/// <param name="value"><see cref="double"/> ��������.</param>
		/// <returns>������ <see cref="Unit"/>.</returns>
		public static implicit operator Unit(double value)
		{
			return (decimal)value;
		}

		/// <summary>
		/// �������� ������ <see cref="Unit"/> � <see cref="double"/> ��������.
		/// </summary>
		/// <param name="unit">������ <see cref="Unit"/>.</param>
		/// <returns><see cref="double"/> ��������.</returns>
		public static explicit operator double(Unit unit)
		{
			return (double)(decimal)unit;
		}

		///// <summary>
		///// �������� <see cref="string"/> �������� � ������� <see cref="Unit"/>.
		///// </summary>
		///// <param name="value"><see cref="string"/> ��������.</param>
		///// <returns>������ <see cref="Unit"/>.</returns>
		//public static implicit operator Unit(string value)
		//{
		//    return value.ToUnit(null);
		//}

		private decimal SafeGetTypeValue(Func<UnitTypes, decimal?> getTypeValue)
		{
			var func = GetTypeValue ?? getTypeValue;

			if (func == null)
				throw new InvalidOperationException("���������� ��������� �������� �� ����������.");

			var value = func(Type);

			if (value != null && value != 0)
				return value.Value;

			if (getTypeValue == null)
				throw new ArgumentNullException("getTypeValue");

			value = getTypeValue(Type);

			if (value == null || value == 0)
				throw new InvalidOperationException(LocalizedStrings.Str1291);

			return value.Value;
		}

		private static Unit CreateResult(Unit u1, Unit u2, Func<decimal, decimal, decimal> operation, Func<decimal, decimal, decimal> percentOperation)
		{
			//  ������������ ����� ����������������� ���������
			//if (u1 == null)
			if (u1.IsNull())
				throw new ArgumentNullException("u1");

			//if (u2 == null)
			if (u2.IsNull())
				throw new ArgumentNullException("u2");

			if (u1.Type == UnitTypes.Limit || u2.Type == UnitTypes.Limit)
				throw new ArgumentException(LocalizedStrings.LimitedValueNotMath);

			if (operation == null)
				throw new ArgumentNullException("operation");

			if (percentOperation == null)
				throw new ArgumentNullException("percentOperation");

			//if (u1.CheckGetTypeValue(false) != u2.CheckGetTypeValue(false))
			//	throw new ArgumentException("� ����� �� ������� �� ����������� ��������� ��������.");

			//if (u1.GetTypeValue != null && u2.GetTypeValue != null && u1.GetTypeValue != u2.GetTypeValue)
			//	throw new ArgumentException(LocalizedStrings.Str614Params.Put(u1.Security.Id, u2.Security.Id));

			var result = new Unit
			{
				Type = u1.Type,
				GetTypeValue = u1.GetTypeValue ?? u2.GetTypeValue
			};

			if (u1.Type == u2.Type)
			{
				result.Value = operation(u1.Value, u2.Value);
			}
			else
			{
				if (u1.Type == UnitTypes.Percent || u2.Type == UnitTypes.Percent)
				{
					result.Type = u1.Type == UnitTypes.Percent ? u2.Type : u1.Type;

					var nonPerValue = u1.Type == UnitTypes.Percent ? u2.Value : u1.Value;
					var perValue = u1.Type == UnitTypes.Percent ? u1.Value : u2.Value;

					result.Value = percentOperation(nonPerValue, perValue * nonPerValue.Abs() / 100.0m);
				}
				else
				{
					var value = operation((decimal)u1, (decimal)u2);

					switch (result.Type)
					{
						case UnitTypes.Absolute:
							break;
						case UnitTypes.Point:
							value /= u1.SafeGetTypeValue(result.GetTypeValue);
							break;
						case UnitTypes.Step:
							value /= u1.SafeGetTypeValue(result.GetTypeValue);
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

					result.Value = value;
				}
			}

			return result;
		}

		/// <summary>
		/// ������� ��� ������� <see cref="Unit"/>.
		/// </summary>
		/// <param name="u1">������ ������ <see cref="Unit"/>.</param>
		/// <param name="u2">������ ������ <see cref="Unit"/>.</param>
		/// <returns>��������� ��������.</returns>
		public static Unit operator +(Unit u1, Unit u2)
		{
			return CreateResult(u1, u2, (v1, v2) => v1 + v2, (nonPer, per) => nonPer + per);
		}

		/// <summary>
		/// ����������� ��� ������� <see cref="Unit"/>.
		/// </summary>
		/// <param name="u1">������ ������ <see cref="Unit"/>.</param>
		/// <param name="u2">������ ������ <see cref="Unit"/>.</param>
		/// <returns>��������� ������������.</returns>
		public static Unit operator *(Unit u1, Unit u2)
		{
			return CreateResult(u1, u2, (v1, v2) => v1 * v2, (nonPer, per) => nonPer * per);
		}

		/// <summary>
		/// ������� ���� �������� <see cref="Unit"/> �� ������.
		/// </summary>
		/// <param name="u1">������ ������ <see cref="Unit"/>.</param>
		/// <param name="u2">������ ������ <see cref="Unit"/>.</param>
		/// <returns>��������� ���������.</returns>
		public static Unit operator -(Unit u1, Unit u2)
		{
			return CreateResult(u1, u2, (v1, v2) => v1 - v2, (nonPer, per) => (u1.Type == UnitTypes.Percent ? (per - nonPer) : (nonPer - per)));
		}

		/// <summary>
		/// �������� ���� �������� <see cref="Unit"/> �� ������.
		/// </summary>
		/// <param name="u1">������ ������ <see cref="Unit"/>.</param>
		/// <param name="u2">������ ������ <see cref="Unit"/>.</param>
		/// <returns>��������� �������.</returns>
		public static Unit operator /(Unit u1, Unit u2)
		{
			return CreateResult(u1, u2, (v1, v2) => v1 / v2, (nonPer, per) => u1.Type == UnitTypes.Percent ? per / nonPer : nonPer / per);
		}

		/// <summary>
		/// ���������� ���-��� ������� <see cref="Unit"/>.
		/// </summary>
		/// <returns>���-���.</returns>
		public override int GetHashCode()
		{
			return Type.GetHashCode() ^ Value.GetHashCode();
		}

		/// <summary>
		/// �������� �������� �� ��������������� � ������.
		/// </summary>
		/// <param name="other">������ ��������, � ������� ���������� ����������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ����� �������, �����, <see langword="false"/>.</returns>
		protected override bool OnEquals(Unit other)
		{
			//var retVal = Type == other.Type && Value == other.Value;

			//if (Type == UnitTypes.Percent || Type == UnitTypes.Absolute || Type == UnitTypes.Limit)
			//	return retVal;

			//return retVal && CheckGetTypeValue(true) == other.CheckGetTypeValue(true);

			if (Type == other.Type)
				return Value == other.Value;

			if (Type == UnitTypes.Percent || other.Type == UnitTypes.Percent)
				return false;

			var curr = this;

			if (other.Type == UnitTypes.Absolute)
				curr = Convert(other.Type);
			else
				other = other.Convert(Type);

			return curr.Value == other.Value;
		}

		/// <summary>
		/// �������� �������� �� ��������������� � ������.
		/// </summary>
		/// <param name="obj">������ ��������, � ������� ���������� ����������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ����� �������, �����, <see langword="false"/>.</returns>
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>
		/// �������� ��� �������� �� ����������� (���� �������� ������ �����, �� ��� ��������� ����� ��������� �����������).
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� �������� �� �����, �����, <see langword="false"/>.</returns>
		public static bool operator !=(Unit u1, Unit u2)
		{
			return !(u1 == u2);
		}

		/// <summary>
		/// �������� ��� �������� �� ��������� (���� �������� ������ �����, �� ��� ��������� ����� ��������� �����������).
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� �������� �����, �����, <see langword="false"/>.</returns>
		public static bool operator ==(Unit u1, Unit u2)
		{
			if (ReferenceEquals(u1, null))
				return u2.IsNull();

			if (ReferenceEquals(u2, null))
				return false;

			return u1.OnEquals(u2);
		}

		/// <summary>
		/// �������� ��������� �������������.
		/// </summary>
		/// <returns>��������� �������������.</returns>
		public override string ToString()
		{
			switch (Type)
			{
				case UnitTypes.Percent:
					return Value + "%";
				case UnitTypes.Absolute:
					return Value.To<string>();
				case UnitTypes.Step:
					return Value + (LocalizedStrings.ActiveLanguage == Languages.Russian ? "�" : "s");
				case UnitTypes.Point:
					return Value + (LocalizedStrings.ActiveLanguage == Languages.Russian ? "�" : "p");
				case UnitTypes.Limit:
					return Value + (LocalizedStrings.ActiveLanguage == Languages.Russian ? "�" : "l");
				default:
					throw new InvalidOperationException(LocalizedStrings.UnknownUnitMeasurement.Put(Type));
			}
		}

		/// <summary>
		/// ��������� �������� � ������ ��� ���������.
		/// </summary>
		/// <param name="destinationType">��� ���������, � ������� ���������� ���������.</param>
		/// <returns>����������������� ��������.</returns>
		public Unit Convert(UnitTypes destinationType)
		{
			return Convert(destinationType, GetTypeValue);
		}

		/// <summary>
		/// ��������� �������� � ������ ��� ���������.
		/// </summary>
		/// <param name="destinationType">��� ���������, � ������� ���������� ���������.</param>
		/// <param name="getTypeValue">����������, ������������ ��������, ��������������� � <see cref="Type"/> (��� ���� ��� ������).</param>
		/// <returns>����������������� ��������.</returns>
		public Unit Convert(UnitTypes destinationType, Func<UnitTypes, decimal?> getTypeValue)
		{
			if (Type == destinationType)
				return Clone();

			if (Type == UnitTypes.Percent || destinationType == UnitTypes.Percent)
				throw new InvalidOperationException(LocalizedStrings.PercentagesConvert);

			var value = (decimal)this;

			if (destinationType == UnitTypes.Point || destinationType == UnitTypes.Step)
			{
				if (getTypeValue == null)
					throw new ArgumentException(LocalizedStrings.UnitHandlerNotSet, "destinationType");

				switch (destinationType)
				{
					case UnitTypes.Point:
						var point = getTypeValue(UnitTypes.Point);

						if (point == null || point == 0)
							throw new InvalidOperationException("Price step cost is equal to zero.".Translate());

						value /= point.Value;
						break;
					case UnitTypes.Step:
						var step = getTypeValue(UnitTypes.Step);

						if (step == null || step == 0)
							throw new InvalidOperationException(LocalizedStrings.Str1546);

						value /= step.Value;
						break;
				}
			}

			return new Unit(value, destinationType, getTypeValue);
		}

		/// <summary>
		/// ���������, �������� �� ������ �������� ������ ������.
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ������ ������, �����, <see langword="false"/>.</returns>
		public static bool operator >(Unit u1, Unit u2)
		{
			if (u1.IsNull())
				throw new ArgumentNullException("u1");

			if (u2.IsNull())
				throw new ArgumentNullException("u2");

			//if (u1.Type == UnitTypes.Limit || u2.Type == UnitTypes.Limit)
			//	throw new ArgumentException("�������������� �������� �� ����� ����������� � �������������� ���������.");

			//if (u1.CheckGetTypeValue(false) != u2.CheckGetTypeValue(false))
			//	throw new ArgumentException("� ����� �� ������� �� ����������� ��������� ��������.");

			if (u1.Type != u2.Type)
			{
				if (u1.Type == UnitTypes.Percent || u2.Type == UnitTypes.Percent)
					throw new ArgumentException(LocalizedStrings.PercentagesCannotCompare.Put(u1, u2));

				if (u2.Type == UnitTypes.Absolute)
					u1 = u1.Convert(u2.Type);
				else
					u2 = u2.Convert(u1.Type);
			}

			return u1.Value > u2.Value;
		}

		/// <summary>
		/// ���������, �������� �� ������ �������� ������ ��� ������ ������.
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ������ ��� ������ ������, �����, <see langword="false"/>.</returns>
		public static bool operator >=(Unit u1, Unit u2)
		{
			return u1 == u2 || u1 > u2;
		}

		/// <summary>
		/// ���������, �������� �� ������ �������� ������ ������.
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ������ ������, �����, <see langword="false"/>.</returns>
		public static bool operator <(Unit u1, Unit u2)
		{
			return u1 != u2 && !(u1 > u2);
		}

		/// <summary>
		/// ���������, �������� �� ������ �������� ������ ��� ������ ������.
		/// </summary>
		/// <param name="u1">������ ��������.</param>
		/// <param name="u2">������ ��������.</param>
		/// <returns><see langword="true"/>, ���� ������ �������� ������ ��� ������ ������, �����, <see langword="false"/>.</returns>
		public static bool operator <=(Unit u1, Unit u2)
		{
			return !(u1 > u2);
		}

		/// <summary>
		/// �������� �������� � ��������������� ������ � �������� <see cref="Value"/>.
		/// </summary>
		/// <param name="u">��������.</param>
		/// <returns>�������� ��������.</returns>
		public static Unit operator -(Unit u)
		{
			if (u == null)
				throw new ArgumentNullException("u");

			return new Unit
			{
				GetTypeValue = u.GetTypeValue,
				Type = u.Type,
				Value = -u.Value
			};
		}

		Unit IOperable<Unit>.Add(Unit other)
		{
			return this + other;
		}

		Unit IOperable<Unit>.Subtract(Unit other)
		{
			return this - other;
		}

		Unit IOperable<Unit>.Multiply(Unit other)
		{
			return this * other;
		}

		Unit IOperable<Unit>.Divide(Unit other)
		{
			return this / other;
		}
	}

	/// <summary>
	/// ��������������� ����� ��� <see cref="Unit"/>.
	/// </summary>
	public static class UnitHelper
	{
		/// <summary>
		/// ������� �� <see cref="int"/> �������� ��������.
		/// </summary>
		/// <param name="value"><see cref="int"/> ��������.</param>
		/// <returns>��������.</returns>
		public static Unit Percents(this int value)
		{
			return Percents((decimal)value);
		}

		/// <summary>
		/// ������� �� <see cref="double"/> �������� ��������.
		/// </summary>
		/// <param name="value"><see cref="double"/> ��������.</param>
		/// <returns>��������.</returns>
		public static Unit Percents(this double value)
		{
			return Percents((decimal)value);
		}

		/// <summary>
		/// ������� �� <see cref="decimal"/> �������� ��������.
		/// </summary>
		/// <param name="value"><see cref="decimal"/> ��������.</param>
		/// <returns>��������.</returns>
		public static Unit Percents(this decimal value)
		{
			return new Unit(value, UnitTypes.Percent);
		}

		/// <summary>
		/// ������������ ������ � <see cref="Unit"/>.
		/// </summary>
		/// <param name="str">��������� ������������� <see cref="Unit"/>.</param>
		/// <param name="getTypeValue">����������, ������������ ��������, ��������������� � <see cref="Type"/> (��� ���� ��� ������).</param>
		/// <returns>������ <see cref="Unit"/>.</returns>
		public static Unit ToUnit(this string str, Func<UnitTypes, decimal?> getTypeValue = null)
		{
			if (str.IsEmpty())
				throw new ArgumentNullException("str");

			var lastSymbol = str.Last();

			if (char.IsDigit(lastSymbol))
				return new Unit(str.To<decimal>(), UnitTypes.Absolute);

			var value = str.Substring(0, str.Length - 1).To<decimal>();

			UnitTypes type;

			switch (lastSymbol)
			{
				case '�':
				case 's':
					if (getTypeValue == null)
						throw new ArgumentNullException("getTypeValue");

					type = UnitTypes.Step;
					break;
				case '�':
				case 'p':
					if (getTypeValue == null)
						throw new ArgumentNullException("getTypeValue");
			
					type = UnitTypes.Point;
					break;
				case '%':
					type = UnitTypes.Percent;
					break;
				case '�':
				case 'l':
					type = UnitTypes.Limit;
					break;
				default:
					throw new ArgumentException(LocalizedStrings.UnknownUnitMeasurement.Put(lastSymbol), "str");
			}

			return new Unit(value, type, getTypeValue);
		}
	}
}