namespace StockSharp.Sterling
{
	using System;
	using System.ComponentModel;
	using System.Runtime.Serialization;

	using Ecng.Collections;

	using StockSharp.Messages;

	using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

	/// <summary>
	/// ����������� ���� ������.
	/// </summary>
	public enum SterlingExtendedOrderTypes
	{
		/// <summary>
		/// �������� �� ��������.
		/// </summary>
		MarketOnClose,

		/// <summary>
		/// �������� ��� �����.
		/// </summary>
		MarketOrBetter,

		/// <summary>
		/// �������� ��� ��������.
		/// </summary>
		MarketNoWait,

		/// <summary>
		/// �������� �� ��������.
		/// </summary>
		LimitOnClose,

		/// <summary>
		/// ����.
		/// </summary>
		Stop,

		/// <summary>
		/// ����-�����
		/// </summary>
		StopLimit,

		/// <summary>
		/// �������� ��� �����
		/// </summary>
		LimitOrBetter,

		/// <summary>
		/// �������� ��� ��������.
		/// </summary>
		LimitNoWait,

		/// <summary>
		/// ��� ��������
		/// </summary>
		NoWait,

		/// <summary>
		/// 
		/// </summary>
		Nyse,

		/// <summary>
		/// �� ��������.
		/// </summary>
		Close,

		/// <summary>
		/// �����������.
		/// </summary>
		Pegged,

		/// <summary>
		/// ��������� ����.
		/// </summary>
		ServerStop,

		/// <summary>
		/// ��������� ����-�����.
		/// </summary>
		ServerStopLimit,

		/// <summary>
		/// ���������� ����.
		/// </summary>
		TrailingStop,

		/// <summary>
		/// �� ��������� ����.
		/// </summary>
		Last
	}

	/// <summary>
	/// ���������� ����������.
	/// </summary>
	public enum SterlingExecutionInstructions
	{
		/// <summary>
		/// � ���������������.
		/// </summary>
		SweepReserve,

		/// <summary>
		/// ��� �����������.
		/// </summary>
		NoPreference
	}

	/// <summary>
	/// ������� ������, ����������� ��� <see cref="Sterling"/>.
	/// </summary>
	[Serializable]
	[DataContract]
	[DisplayName("������� ������ ��� Sterling")]
	public class SterlingOrderCondition : OrderCondition
	{
		/// <summary>
		/// ��������� ��� ������ �� �������.
		/// </summary>
		public class SterlingOptionOrderCondition
		{
			private readonly SterlingOrderCondition _condition;

			internal SterlingOptionOrderCondition(SterlingOrderCondition condition)
			{
				_condition = condition;
			}

			/// <summary>
			/// ��������.
			/// </summary>
			public bool? IsOpen
			{
				get { return (bool?)_condition.Parameters.TryGetValue("OptionIsOpen"); }
				set { _condition.Parameters["OptionIsOpen"] = value; }
			}

			/// <summary>
			/// ���� ��������.
			/// </summary>
			public DateTime? Maturity
			{
				get { return (DateTime?)_condition.Parameters.TryGetValue("OptionMaturity"); }
				set { _condition.Parameters["OptionMaturity"] = value; }
			}

			/// <summary>
			/// ��� �������.
			/// </summary>
			public OptionTypes? Type
			{
				get { return (OptionTypes?)_condition.Parameters.TryGetValue("OptionType"); }
				set { _condition.Parameters["OptionType"] = value; }
			}

			/// <summary>
			/// ��� �������� ������.
			/// </summary>
			public string UnderlyingCode
			{
				get { return (string)_condition.Parameters.TryGetValue("OptionUnderlyingCode"); }
				set { _condition.Parameters["OptionUnderlyingCode"] = value; }
			}

			/// <summary>
			/// �������� ������.
			/// </summary>
			public bool? IsCover
			{
				get { return (bool?)_condition.Parameters.TryGetValue("OptionIsCover"); }
				set { _condition.Parameters["OptionIsCover"] = value; }
			}

			/// <summary>
			/// ��� �������� ������.
			/// </summary>
			public SecurityTypes? UnderlyingType
			{
				get { return (SecurityTypes?)_condition.Parameters.TryGetValue("OptionUnderlyingType"); }
				set { _condition.Parameters["OptionUnderlyingType"] = value; }
			}

			/// <summary>
			/// ������-����.
			/// </summary>
			public decimal? StrikePrice
			{
				get { return (decimal?)_condition.Parameters.TryGetValue("OptionStrikePrice"); }
				set { _condition.Parameters["OptionStrikePrice"] = value; }
			}
		}

		/// <summary>
		/// ������� <see cref="SterlingOrderCondition"/>.
		/// </summary>
		public SterlingOrderCondition()
		{
			Options = new SterlingOptionOrderCondition(this);
		}

		/// <summary>
		/// ���� ���������, ��� ���������� ������� ����� ���������� ������.
		/// </summary>
		[DataMember]
		[Category("����")]
		[DisplayName("���� ���������")]
		[Description("���� ���������, ��� ���������� ������� ����� ���������� ������.")]
		public decimal? StopPrice 
		{
			get { return (decimal?)Parameters.TryGetValue("StopPrice"); }
			set { Parameters["StopPrice"] = value; }
		}

		/// <summary>
		/// ����������� ��� ������.
		/// </summary>
		[DataMember]
		[Category("��������")]
		[DisplayName("����������� ��� ������")]
		[Description("����������� ��� ������.")]
		public SterlingExtendedOrderTypes? ExtendedOrderType
		{
			get { return (SterlingExtendedOrderTypes?)Parameters.TryGetValue("ExtendedOrderType"); }
			set { Parameters["ExtendedOrderType ="] = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? Discretion { get; set; }

		/// <summary>
		/// ���������� ����������.
		/// </summary>
		public SterlingExecutionInstructions ExecutionInstruction { get; set; }

		/// <summary>
		/// ����������� ������.
		/// </summary>
		public string ExecutionBroker { get; set; }

		/// <summary>
		/// ����� ���� ����������.
		/// </summary>
		public decimal? ExecutionPriceLimit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? PegDiff { get; set; }

		/// <summary>
		/// ����� ����������� �����.
		/// </summary>
		public decimal? TrailingVolume { get; set; }

		/// <summary>
		/// ��� ���������� ���� ����������� �����.
		/// </summary>
		public decimal? TrailingIncrement { get; set; }

		/// <summary>
		/// ����������� �����.
		/// </summary>
		public decimal? MinVolume { get; set; }

		/// <summary>
		/// ������� ���� ����������.
		/// </summary>
		public decimal? AveragePriceLimit { get; set; }

		/// <summary>
		/// �����������������.
		/// </summary>
		public int? Duration { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LocateBroker { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? LocateVolume { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? LocateTime { get; set; }

		/// <summary>
		/// ��������� ��� ������ �� �������.
		/// </summary>
		[DisplayName("�������")]
		[Description("��������� ��� ������ �� �������.")]
		[ExpandableObject]
		public SterlingOptionOrderCondition Options { get; private set; }
	}
}