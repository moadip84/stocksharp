namespace StockSharp.Messages
{
	using System;
	using System.Collections.Generic;

	using Ecng.Common;
	using Ecng.Interop;
	using Ecng.Localization;
	using Ecng.Serialization;

	using StockSharp.Logging;

	/// <summary>
	/// ����������������.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TargetPlatformAttribute : Attribute
	{
		/// <summary>
		/// ������� ���������.
		/// </summary>
		public Languages PreferLanguage { get; private set; }

		/// <summary>
		/// ���������.
		/// </summary>
		public Platforms Platform { get; private set; }

		/// <summary>
		/// ������� <see cref="TargetPlatformAttribute"/>.
		/// </summary>
		/// <param name="preferLanguage">������� ���������.</param>
		/// <param name="platform">���������.</param>
		public TargetPlatformAttribute(Languages preferLanguage = Languages.English, Platforms platform = Platforms.AnyCPU)
		{
			PreferLanguage = preferLanguage;
			Platform = platform;
		}
	}

	/// <summary>
	/// ���������, ����������� ��������� ��� ������.
	/// </summary>
	public interface IMessageSessionHolder : IPersistable, ILogReceiver, IMessageChannel
	{
		/// <summary>
		/// ��������� ��������������� ����������.
		/// </summary>
		IdGenerator TransactionIdGenerator { get; }

		/// <summary>
		/// <see langword="true"/>, ���� ������ ������������ ��� ��������� ������-������, �����, <see langword="false"/>.
		/// </summary>
		bool IsMarketDataEnabled { get; set; }

		/// <summary>
		/// <see langword="true"/>, ���� ������ ������������ ��� �������� ����������, �����, <see langword="false"/>.
		/// </summary>
		bool IsTransactionEnabled { get; set; }

		/// <summary>
		/// ��������� ��������� ��������� �� ����������.
		/// </summary>
		bool IsValid { get; }

		/// <summary>
		/// ���������� ����������� �������� ��������� ��� ���������.
		/// </summary>
		bool JoinInProcessors { get; }

		/// <summary>
		/// ���������� ����������� ��������� ��������� ��� ���������.
		/// </summary>
		bool JoinOutProcessors { get; }

		/// <summary>
		/// �������� ������� ������������, � ����������� �� ������� ����� ������������� ��������� � <see cref="SecurityMessage.SecurityType"/> � <see cref="SecurityId.BoardCode"/>.
		/// </summary>
		IDictionary<string, RefPair<SecurityTypes, string>> SecurityClassInfo { get; }

		/// <summary>
		/// ��������� ��������� ������������ ����������.
		/// </summary>
		MessageAdapterReConnectionSettings ReConnectionSettings { get; }

		/// <summary>
		/// �������� ���������� ������� � ���, ��� ����������� ��� �����. ��-��������� ����� 1 ������.
		/// </summary>
		TimeSpan HeartbeatInterval { get; set; }

		/// <summary>
		/// �������� ��������� ��������� <see cref="TimeMessage"/>. ��-��������� ����� 10 �������������.
		/// </summary>
		TimeSpan MarketTimeChangedInterval { get; set; }

		/// <summary>
		/// �������� �� ����������� ��������� ������������ ���� �� �����.
		/// </summary>
		bool IsAdaptersIndependent { get; }

		/// <summary>
		/// ��������� ������������ ���������� ��� ������������ � ������ �������� ��������.
		/// </summary>
		bool CreateAssociatedSecurity { get; set; }

		/// <summary>
		/// ��������� ������ ��� ����������� ��� ��������� ��������� <see cref="Level1ChangeMessage"/>.
		/// </summary>
		bool CreateDepthFromLevel1 { get; set; }

		/// <summary>
		/// ��� �������� ��� ������������� �����������.
		/// </summary>
		string AssociatedBoardCode { get; set; }

		/// <summary>
		/// ������� ��� ������ ���� <see cref="OrderTypes.Conditional"/> �������, ������� �������������� ������������.
		/// </summary>
		/// <returns>������� ��� ������. ���� ����������� �� ������������ ������ ���� <see cref="OrderTypes.Conditional"/>, �� ����� ���������� null.</returns>
		OrderCondition CreateOrderCondition();

		/// <summary>
		/// ������� �������������� �������.
		/// </summary>
		/// <returns>�������������� �������.</returns>
		IMessageAdapter CreateTransactionAdapter();

		/// <summary>
		/// ������� ������� ������-������.
		/// </summary>
		/// <returns>������� ������-������.</returns>
		IMessageAdapter CreateMarketDataAdapter();
	}
}