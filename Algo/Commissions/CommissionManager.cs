namespace StockSharp.Algo.Commissions
{
	using System;
	using System.Linq;

	using Ecng.Collections;
	using Ecng.Serialization;

	using MoreLinq;

	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// �������� ������� ��������.
	/// </summary>
	public class CommissionManager : ICommissionManager
	{
		/// <summary>
		/// ������� <see cref="CommissionManager"/>.
		/// </summary>
		public CommissionManager()
		{
		}

		private readonly CachedSynchronizedSet<ICommissionRule> _rules = new CachedSynchronizedSet<ICommissionRule>();

		/// <summary>
		/// ������ ������ ���������� ��������.
		/// </summary>
		public ISynchronizedCollection<ICommissionRule> Rules
		{
			get { return _rules; }
		}

		/// <summary>
		/// ��������� �������� ��������.
		/// </summary>
		public virtual decimal Commission { get; private set; }

		/// <summary>
		/// �������� ���������.
		/// </summary>
		public virtual void Reset()
		{
			Commission = 0;
			_rules.Cache.ForEach(r => r.Reset());
		}

		/// <summary>
		/// ���������� ��������.
		/// </summary>
		/// <param name="message">���������, ���������� ���������� �� ������ ��� ����������� ������.</param>
		/// <returns>��������. ���� �������� ���������� ����������, �� ����� ���������� <see langword="null"/>.</returns>
		public virtual decimal? ProcessExecution(ExecutionMessage message)
		{
			var commission = _rules.Cache.Sum(rule => rule.ProcessExecution(message));

			if (commission != null)
				Commission += commission.Value;

			return commission;
		}

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">���������.</param>
		public void Load(SettingsStorage storage)
		{
			Rules.AddRange(storage.GetValue<SettingsStorage[]>("Rules").Select(s => s.LoadEntire<ICommissionRule>()));
		}

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">���������.</param>
		public void Save(SettingsStorage storage)
		{
			storage.SetValue("Rules", Rules.Select(r => r.SaveEntire(false)).ToArray());
		}

		string ICommissionRule.Title
		{
			get { throw new NotSupportedException(); }
		}

		Unit ICommissionRule.Value
		{
			get { throw new NotSupportedException(); }
		}
	}
}