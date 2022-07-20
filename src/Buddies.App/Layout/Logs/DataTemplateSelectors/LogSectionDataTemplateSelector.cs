namespace Buddies.App.Layout.Logs.DataTemplateSelectors;

internal class LogSectionDataTemplateSelector : DataTemplateSelector
{
	#region Data Templates

	public DataTemplate GeneralDataTemplate { get; set; }

	public DataTemplate ConditionsDataTemplate { get; set; }

	public DataTemplate EquipmentDataTemplate { get; set; }

	public DataTemplate ExperienceDataTemplate { get; set; }

	#endregion

	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
	{
		if (item is not LogSection section)
		{
			throw new NotSupportedException("LogSectionDataTemplateSelector does not support the provided data type.");
		}

		return section switch
		{
			LogSection.General => GeneralDataTemplate,
			LogSection.Conditions => ConditionsDataTemplate,
			LogSection.Equipment => EquipmentDataTemplate,
			LogSection.Experience => ExperienceDataTemplate,
			_ => throw new NotSupportedException("LogSectionDataTemplateSelector does not support the provided log section.")
		};
	}
}
