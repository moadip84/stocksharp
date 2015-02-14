namespace StockSharp.Algo.Export
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.IO;
	using System.Linq;

	using SmartFormat;
	using SmartFormat.Core;

	using StockSharp.Algo;
	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// ������� � ��������� ����.
	/// </summary>
	public class TextExporter : BaseExporter
	{
		/// <summary>
		/// ������� <see cref="TextExporter"/>.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <param name="arg">�������� ������.</param>
		/// <param name="isCancelled">����������, ������������ ������� ���������� ��������.</param>
		/// <param name="fileName">���� � �����.</param>
		public TextExporter(Security security, object arg, Func<int, bool> isCancelled, string fileName)
			: base(security, arg, isCancelled, fileName)
		{
		}

		/// <summary>
		/// �������������� <see cref="ExecutionMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<ExecutionMessage> messages)
		{
			string template;

			switch ((ExecutionTypes)Arg)
			{
				case ExecutionTypes.Tick:
				case ExecutionTypes.Trade:
					template = "txt_export_trades";
					break;
				case ExecutionTypes.Order:
					template = "txt_export_executions";
					break;
				case ExecutionTypes.OrderLog:
					template = "txt_export_orderlog";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			Do(messages, template);
		}

		/// <summary>
		/// �������������� <see cref="QuoteChangeMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<QuoteChangeMessage> messages)
		{
			Do(messages.SelectMany(d => d.Asks.Concat(d.Bids).OrderByDescending(q => q.Price).Select(q => new TimeQuoteChange(q, d))), "txt_export_depths");
		}

		/// <summary>
		/// �������������� <see cref="Level1ChangeMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<Level1ChangeMessage> messages)
		{
			Do(messages, "txt_export_level1");
		}

		/// <summary>
		/// �������������� <see cref="CandleMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<CandleMessage> messages)
		{
			Do(messages, "txt_export_candles");
		}

		/// <summary>
		/// �������������� <see cref="NewsMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<NewsMessage> messages)
		{
			Do(messages, "txt_export_news");
		}

		/// <summary>
		/// �������������� <see cref="SecurityMessage"/>.
		/// </summary>
		/// <param name="messages">���������.</param>
		protected override void Export(IEnumerable<SecurityMessage> messages)
		{
			Do(messages, "txt_export_securities");
		}

		private void Do<TValue>(IEnumerable<TValue> values, string templateName)
		{
			using (var writer = new StreamWriter(Path))
			{
				var template = ConfigurationManager.AppSettings.Get(templateName);

				FormatCache templateCache = null;
				var formater = Smart.Default;

				foreach (var value in values)
				{
					if (!CanProcess())
						break;

					writer.WriteLine(formater.FormatWithCache(ref templateCache, template, value));
				}

				writer.Flush();
			}
		}
	}
}