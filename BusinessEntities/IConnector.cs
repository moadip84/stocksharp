namespace StockSharp.BusinessEntities
{
	using System;
	using System.Collections.Generic;

	using Ecng.Serialization;

	using StockSharp.Logging;
	using StockSharp.Messages;

	/// <summary>
	/// ��������� �����������.
	/// </summary>
	public enum ConnectionStates
	{
		/// <summary>
		/// �� �������.
		/// </summary>
		Disconnected,

		/// <summary>
		/// � �������� ����������.
		/// </summary>
		Disconnecting,

		/// <summary>
		/// � �������� �����������.
		/// </summary>
		Connecting,

		/// <summary>
		/// ����������� �������.
		/// </summary>
		Connected,

		/// <summary>
		/// ������ �����������.
		/// </summary>
		Failed,
	}

	/// <summary>
	/// �������� ���������, ��������������� ����������� � ��������� ���������.
	/// </summary>
	public interface IConnector : IPersistable, ILogReceiver, IMarketDataProvider, ISecurityProvider
	{
		/// <summary>
		/// ������� ��������� ����������� ����� ������.
		/// </summary>
		event Action<IEnumerable<MyTrade>> NewMyTrades;

		/// <summary>
		/// ������� ��������� ���� ����� ������.
		/// </summary>
		event Action<IEnumerable<Trade>> NewTrades;

		/// <summary>
		/// ������� ��������� ����� ������.
		/// </summary>
		event Action<IEnumerable<Order>> NewOrders;

		/// <summary>
		/// ������� ��������� ��������� ������ (�����, �������������).
		/// </summary>
		event Action<IEnumerable<Order>> OrdersChanged;

		/// <summary>
		/// ������� �� �������, ��������� � ������������ ������.
		/// </summary>
		event Action<IEnumerable<OrderFail>> OrdersRegisterFailed;

		/// <summary>
		/// ������� �� �������, ��������� �� ������� ������.
		/// </summary>
		event Action<IEnumerable<OrderFail>> OrdersCancelFailed;

		/// <summary>
		/// ������� �� �������, ��������� � ������������ ����-������.
		/// </summary>
		event Action<IEnumerable<OrderFail>> StopOrdersRegisterFailed;

		/// <summary>
		/// ������� �� �������, ��������� �� ������� ����-������.
		/// </summary>
		event Action<IEnumerable<OrderFail>> StopOrdersCancelFailed;

		/// <summary>
		/// ������� ��������� ����� ����-������.
		/// </summary>
		event Action<IEnumerable<Order>> NewStopOrders;

		/// <summary>
		/// ������� ��������� ��������� ����-������.
		/// </summary>
		event Action<IEnumerable<Order>> StopOrdersChanged;

		/// <summary>
		/// ������� ��������� ����� ������������.
		/// </summary>
		event Action<IEnumerable<Security>> NewSecurities;

		/// <summary>
		/// ������� ��������� ���������� ������������.
		/// </summary>
		event Action<IEnumerable<Security>> SecuritiesChanged;

		/// <summary>
		/// ������� ��������� ����� ���������.
		/// </summary>
		event Action<IEnumerable<Portfolio>> NewPortfolios;

		/// <summary>
		/// ������� ��������� ���������� ���������.
		/// </summary>
		event Action<IEnumerable<Portfolio>> PortfoliosChanged;

		/// <summary>
		/// ������� ��������� ����� �������.
		/// </summary>
		event Action<IEnumerable<Position>> NewPositions;

		/// <summary>
		/// ������� ��������� ���������� �������.
		/// </summary>
		event Action<IEnumerable<Position>> PositionsChanged;

		/// <summary>
		/// ������� ��������� ����� �������� � �����������.
		/// </summary>
		event Action<IEnumerable<MarketDepth>> NewMarketDepths;

		/// <summary>
		/// ������� ��������� �������� � �����������.
		/// </summary>
		event Action<IEnumerable<MarketDepth>> MarketDepthsChanged;

		/// <summary>
		/// ������� ��������� ����� ������� � ���� ������.
		/// </summary>
		event Action<IEnumerable<OrderLogItem>> NewOrderLogItems;

		/// <summary>
		/// ������� ��������� �������.
		/// </summary>
		event Action<News> NewNews;

		/// <summary>
		/// ������� ��������� ������� (��������, ��� ���������� ������ <see cref="StockSharp.BusinessEntities.News.Story"/>).
		/// </summary>
		event Action<News> NewsChanged;

		/// <summary>
		/// ������� ��������� ������ ��������� <see cref="Message"/>.
		/// </summary>
		event Action<Message, MessageDirections> NewMessage;

		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		event Action Connected;

		/// <summary>
		/// ������� ��������� ����������.
		/// </summary>
		event Action Disconnected;

		/// <summary>
		/// ������� ������ ����������� (��������, ���������� ���� ���������).
		/// </summary>
		event Action<Exception> ConnectionError;

		/// <summary>
		/// ������� ��������� ������� ��������.
		/// </summary>
		event Action ExportStarted;

		/// <summary>
		/// ������� �������� ��������� ��������.
		/// </summary>
		event Action ExportStopped;

		/// <summary>
		/// ������� ������ �������� (��������, ���������� ���� ���������).
		/// </summary>
		event Action<Exception> ExportError;

		/// <summary>
		/// �������, ��������������� �� ������ ��� ��������� ��� ��������� ����� ������ � �������.
		/// </summary>
		event Action<Exception> ProcessDataError;

		/// <summary>
		/// �������, ��������������� � ����� �������������� ������.
		/// </summary>
		event Action NewDataExported;

		/// <summary>
		/// �������, ��������������� �� ��������� �������� ������� �� �������� ��������� <see cref="ExchangeBoards"/>.
		/// ���������� ������� �� �������, ��������� � ���������� ������ �������. ������ ��� ������� �������� �������� <see cref="TimeSpan.Zero"/>.
		/// </summary>
		event Action<TimeSpan> MarketTimeChanged;

		/// <summary>
		/// �������, ���������� ��������� ������, ����������� ����� ����� <see cref="LookupSecurities(StockSharp.BusinessEntities.Security)"/>.
		/// </summary>
		event Action<IEnumerable<Security>> LookupSecuritiesResult;

		/// <summary>
		/// �������, ���������� ��������� ������, ����������� ����� ����� <see cref="LookupPortfolios"/>.
		/// </summary>
		event Action<IEnumerable<Portfolio>> LookupPortfoliosResult;

		/// <summary>
		/// ������� �������� ����������� ����������� ��� ��������� ������-������.
		/// </summary>
		event Action<Security, MarketDataTypes> MarketDataSubscriptionSucceeded;

		/// <summary>
		/// ������� ������ ����������� ����������� ��� ��������� ������-������.
		/// </summary>
		event Action<Security, MarketDataTypes, Exception> MarketDataSubscriptionFailed;

		/// <summary>
		/// ������� ��������� ��������� ������ ��� �������� ��������.
		/// </summary>
		event Action<ExchangeBoard, SessionStates> SessionStateChanged;

		/// <summary>
		/// �������� ��������� ������ ��� �������� ��������.
		/// </summary>
		/// <param name="board">�������� �������� ����������� ������.</param>
		/// <returns>��������� ������. ���� ���������� � ��������� ������ �����������, �� ����� ���������� <see langword="null"/>.</returns>
		SessionStates? GetSessionState(ExchangeBoard board);

		/// <summary>
		/// ������ ���� �������� ��������, ��� ������� ��������� ����������� <see cref="Securities"/>.
		/// </summary>
		IEnumerable<ExchangeBoard> ExchangeBoards { get; }

		/// <summary>
		/// ������ ���� ����������� ������������.
		/// �������� ���������� ����� ����, ��� ������ ������� <see cref="NewSecurities" />. ����� ����� ���������� ������ ���������.
		/// </summary>
		IEnumerable<Security> Securities { get; }

		/// <summary>
		/// �������� ��� ������.
		/// </summary>
		IEnumerable<Order> Orders { get; }

		/// <summary>
		/// �������� ��� ����-������.
		/// </summary>
		IEnumerable<Order> StopOrders { get; }

		/// <summary>
		/// �������� ��� ������ ��� ����������� ������.
		/// </summary>
		IEnumerable<OrderFail> OrderRegisterFails { get; }

		/// <summary>
		/// �������� ��� ������ ��� ������ ������.
		/// </summary>
		IEnumerable<OrderFail> OrderCancelFails { get; }

		/// <summary>
		/// �������� ��� ������.
		/// </summary>
		IEnumerable<Trade> Trades { get; }

		/// <summary>
		/// �������� ��� ����������� ������.
		/// </summary>
		IEnumerable<MyTrade> MyTrades { get; }

		/// <summary>
		/// �������� ��� ��������.
		/// </summary>
		IEnumerable<Portfolio> Portfolios { get; }

		/// <summary>
		/// �������� ��� �������.
		/// </summary>
		IEnumerable<Position> Positions { get; }

		/// <summary>
		/// ��� �������.
		/// </summary>
		IEnumerable<News> News { get; }

		/// <summary>
		/// ��������� ����������.
		/// </summary>
		ConnectionStates ConnectionState { get; }

		/// <summary>
		/// ��������� ��������.
		/// </summary>
		ConnectionStates ExportState { get; }

		/// <summary>
		/// �������������� �� ��������������� ������ ����� ����� <see cref="ReRegisterOrder(StockSharp.BusinessEntities.Order,StockSharp.BusinessEntities.Order)"/>
		/// � ���� ����� ����������.
		/// </summary>
		bool IsSupportAtomicReRegister { get; }

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="RegisterSecurity"/>.
		/// </summary>
		IEnumerable<Security> RegisteredSecurities { get; }

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="RegisterMarketDepth"/>.
		/// </summary>
		IEnumerable<Security> RegisteredMarketDepths { get; }

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="RegisterTrades"/>.
		/// </summary>
		IEnumerable<Security> RegisteredTrades { get; }

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="RegisterOrderLog"/>.
		/// </summary>
		IEnumerable<Security> RegisteredOrderLogs { get; }

		/// <summary>
		/// ������ ���� ���������, ������������������ ����� <see cref="RegisterPortfolio"/>.
		/// </summary>
		IEnumerable<Portfolio> RegisteredPortfolios { get; }

		/// <summary>
		/// ������������ � �������� �������.
		/// </summary>
		void Connect();

		/// <summary>
		/// ����������� �� �������� �������.
		/// </summary>
		void Disconnect();

		/// <summary>
		/// ��������� ������� ������ �� �������� ������� � ��������� (��������� ���������, ������������, ������ � �.�.).
		/// </summary>
		void StartExport();

		/// <summary>
		/// ���������� ������� ������ �� �������� ������� � ���������, ���������� ����� <see cref="StartExport"/>.
		/// </summary>
		void StopExport();

		/// <summary>
		/// ����� �����������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� ����������� ����� �������� ����� ������� <see cref="LookupSecuritiesResult"/>.
		/// </summary>
		/// <param name="criteria">����������, ���� �������� ����� �������������� � �������� �������.</param>
		void LookupSecurities(Security criteria);

		/// <summary>
		/// ����� �����������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� ����������� ����� �������� ����� ������� <see cref="LookupSecuritiesResult"/>.
		/// </summary>
		/// <param name="criteria">��������, ���� �������� ����� �������������� � �������� �������.</param>
		void LookupSecurities(SecurityLookupMessage criteria);

		/// <summary>
		/// ����� ��������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� �������� ����� �������� ����� ������� <see cref="LookupPortfoliosResult"/>.
		/// </summary>
		/// <param name="criteria">��������, ���� �������� ����� �������������� � �������� �������.</param>
		void LookupPortfolios(Portfolio criteria);

		/// <summary>
		/// �������� ������� �� �������� � �����������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ����� ����� �������.</param>
		/// <param name="security">����������, �� �������� ����� ����� �������.</param>
		/// <param name="depoName">�������� �����������, ��� ��������� ��������� ������ ������.
		/// ��-��������� ���������� ������ ������, ��� �������� ��������� ������� �� ���� ������������.</param>
		/// <returns>�������.</returns>
		Position GetPosition(Portfolio portfolio, Security security, string depoName = "");

		/// <summary>
		/// �������� ��������������� ������ ���������.
		/// </summary>
		/// <param name="security">����������, �� �������� ����� �������� ������.</param>
		/// <returns>��������������� ������ ���������.</returns>
		MarketDepth GetFilteredMarketDepth(Security security);

		/// <summary>
		/// ���������������� ������ �� �����.
		/// </summary>
		/// <param name="order">������, ���������� ���������� ��� �����������.</param>
		void RegisterOrder(Order order);

		/// <summary>
		/// ������������������ ������ �� �����.
		/// </summary>
		/// <param name="oldOrder">������, ������� ����� �����.</param>
		/// <param name="newOrder">����� ������, ������� ����� ����������������.</param>
		void ReRegisterOrder(Order oldOrder, Order newOrder);

		/// <summary>
		/// ������������������ ������ �� �����.
		/// </summary>
		/// <param name="oldOrder">������, ������� ����� ����� � �� ������ ��� ���������������� �����.</param>
		/// <param name="price">���� ����� ������.</param>
		/// <param name="volume">����� ����� ������.</param>
		/// <returns>����� ������.</returns>
		Order ReRegisterOrder(Order oldOrder, decimal price, decimal volume);

		/// <summary>
		/// �������� ������ �� �����.
		/// </summary>
		/// <param name="order">������, ������� ����� ��������.</param>
		void CancelOrder(Order order);

		/// <summary>
		/// �������� ������ ������ �� ����� �� �������.
		/// </summary>
		/// <param name="isStopOrder"><see langword="true"/>, ���� ����� �������� ������ ����-������, false - ���� ������ ������� � null - ���� ��� ����.</param>
		/// <param name="portfolio">��������. ���� �������� ����� null, �� �������� �� �������� � ������ ������ ������.</param>
		/// <param name="direction">����������� ������. ���� �������� ����� null, �� ����������� �� �������� � ������ ������ ������.</param>
		/// <param name="board">�������� ��������. ���� �������� ����� null, �� �������� �� �������� � ������ ������ ������.</param>
		/// <param name="security">����������. ���� �������� ����� null, �� ���������� �� �������� � ������ ������ ������.</param>
		void CancelOrders(bool? isStopOrder = null, Portfolio portfolio = null, Sides? direction = null, ExchangeBoard board = null, Security security = null);

		/// <summary>
		/// ����������� �� ��������� �������� ������ �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		/// <param name="type">��� �������� ������.</param>
		void SubscribeMarketData(Security security, MarketDataTypes type);

		/// <summary>
		/// ���������� �� ��������� �������� ������ �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		/// <param name="type">��� �������� ������.</param>
		void UnSubscribeMarketData(Security security, MarketDataTypes type);

		/// <summary>
		/// ������ �������� ��������� (������) �� �����������.
		/// �������� ��������� ����� �������� ����� ������� <see cref="MarketDepthsChanged"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ���������.</param>
		void RegisterMarketDepth(Security security);

		/// <summary>
		/// ���������� ��������� ��������� �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���������.</param>
		void UnRegisterMarketDepth(Security security);

		/// <summary>
		/// ������ �������� ��������������� ��������� (������) �� �����������.
		/// �������� ��������� ����� �������� ����� ����� <see cref="IConnector.GetFilteredMarketDepth"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ���������.</param>
		void RegisterFilteredMarketDepth(Security security);

		/// <summary>
		/// ���������� ��������� ��������������� ��������� �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���������.</param>
		void UnRegisterFilteredMarketDepth(Security security);

		/// <summary>
		/// ������ �������� ������ (������� ������) �� �����������. ����� ������ ����� ��������� �����
		/// ������� <see cref="NewTrades"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ������.</param>
		void RegisterTrades(Security security);

		/// <summary>
		/// ���������� ��������� ������ (������� ������) �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ������.</param>
		void UnRegisterTrades(Security security);

		/// <summary>
		/// ������ �������� ����� ���������� (��������, <see cref="Security.LastTrade"/> ��� <see cref="Security.BestBid"/>) �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		void RegisterSecurity(Security security);

		/// <summary>
		/// ���������� ��������� ����� ����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ����� ����������.</param>
		void UnRegisterSecurity(Security security);

		/// <summary>
		/// ������ �������� ��� ������ ��� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ��� ������.</param>
		void RegisterOrderLog(Security security);

		/// <summary>
		/// ���������� ��������� ���� ������ ��� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���� ������.</param>
		void UnRegisterOrderLog(Security security);

		/// <summary>
		/// ������ �������� ����� ���������� �� ��������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ���������� ������ �������� ����� ����������.</param>
		void RegisterPortfolio(Portfolio portfolio);

		/// <summary>
		/// ���������� ��������� ����� ���������� �� ��������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ���������� ���������� ��������� ����� ����������.</param>
		void UnRegisterPortfolio(Portfolio portfolio);

		/// <summary>
		/// ������ �������� �������.
		/// </summary>
		void RegisterNews();

		/// <summary>
		/// ���������� ��������� ��������.
		/// </summary>
		void UnRegisterNews();

		/// <summary>
		/// ��������� ����� ������� <see cref="BusinessEntities.News.Story"/>. ����� ��������� ������ ����� ������� ������� <see cref="NewsChanged"/>.
		/// </summary>
		/// <param name="news">�������.</param>
		void RequestNewsStory(News news);
	}
}