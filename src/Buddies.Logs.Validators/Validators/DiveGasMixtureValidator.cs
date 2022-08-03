using Buddies.Logs.Abstractions.Entities;
using Buddies.Logs.Abstractions.Enums;
using System.Collections.Immutable;

namespace Buddies.Logs.Validators.Validators
{
	internal class DiveGasMixtureValidator : IEntityValidator<DiveGasMixture>
	{
		/// <summary>
		/// Appends <paramref name="message"/> to <paramref name="messages"/>
		/// grouped by <paramref name="property"/>.
		/// </summary>
		/// <param name="messages">Error messages</param>
		/// <param name="property">Property</param>
		/// <param name="message">Error message</param>
		private static void AppendMessage(Dictionary<string, IImmutableList<string>> messages, string property, string message)
		{
			if (!messages.ContainsKey(property))
			{
				messages.Add(property, ImmutableList.Create(message));
				return;
			}

			messages[property] = messages[property].Add(message);
		}

		#region Gas Mixture Validations

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Air"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateAir(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Air)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen != 21)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Air needs to be composed of 21% Oxygen.");
			}

			if (entity.Nitrogen != 79)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Air needs to be composed of 79% Nitrogen.");
			}

			if (entity.Helium > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Air cannot be blended with Helium.");
			}

			if (entity.Hydrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Air cannot be blended with Hydrogen.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Enriched"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateEnrichedAir(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Enriched)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen < 21)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Enriched Air (EANx) needs a minimum of 22% oxygen.");
			}

			if (entity.Oxygen > 40)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Enriched Air (EANx) cannot exceed 40% oxygen.");
			}

			if (entity.Helium > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Enriched Air (EANx) cannot be blended with Helium.");
			}

			if (entity.Hydrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Enriched Air (EANx) cannot be blended with Hydrogen.");
			}

			if (entity.Oxygen + entity.Nitrogen != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Enriched Air (EANx) requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Trimix"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateTrimix(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Trimix)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Trimix needs to be blended with Oxygen.");
			}

			if (entity.Nitrogen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Trimix needs to be blended with Nitrogen.");
			}

			if (entity.Helium == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Trimix needs to be blended with Helium.");
			}

			if (entity.Hydrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Trimix cannot be blended with Hydrogen.");
			}

			if (entity.Oxygen + entity.Nitrogen + entity.Helium != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Trimix requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Heliox"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateHeliox(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Heliox)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Heliox needs to be blended with Oxygen.");
			}

			if (entity.Nitrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Heliox cannot be blended with Nitrogen.");
			}

			if (entity.Helium == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Heliox needs to be blended with Helium.");
			}

			if (entity.Hydrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Heliox cannot be blended with Hydrogen.");
			}

			if (entity.Oxygen + entity.Helium != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Heliox requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Hydrox"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateHydrox(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Hydrox)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Hydrox needs to be blended with Oxygen.");
			}

			if (entity.Nitrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Hydrox cannot be blended with Nitrogen.");
			}

			if (entity.Helium > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Hydrox cannot be blended with Helium.");
			}

			if (entity.Hydrogen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Hydrox needs to be blended with Hydrogen.");
			}

			if (entity.Oxygen + entity.Hydrogen != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Hydrox requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Hydreliox"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateHydreliox(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Hydreliox)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Hydreliox needs to be blended with Oxygen.");
			}

			if (entity.Nitrogen > 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Nitrogen), "Hydreliox cannot be blended with Nitrogen.");
			}

			if (entity.Helium == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Helium), "Hydreliox needs be blended with Helium.");
			}

			if (entity.Hydrogen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Hydreliox needs to be blended with Hydrogen.");
			}

			if (entity.Oxygen + entity.Helium + entity.Hydrogen != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Hydreliox requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Rebreather"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateRebreather(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Rebreather)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Rebreather needs to be blended with Oxygen.");
			}

			if (entity.Oxygen + entity.Nitrogen + entity.Helium + entity.Hydrogen != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "Rebreather requires a blend that adds up to 100%.");
			}

			return isValid;
		}

		/// <summary>
		/// Ensures that the gas mixture for <see cref="GasMixtureType.Other"/> is valid.
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="messages">Error messages</param>
		/// <returns><see langword="true"/> when all validations succeed.</returns>
		private static bool ValidateOther(DiveGasMixture entity, Dictionary<string, IImmutableList<string>> messages)
		{
			if (entity.GasMixtureType != GasMixtureType.Other)
			{
				return true;
			}

			bool isValid = true;

			if (entity.Oxygen == 0)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Oxygen), "Oxygen is required.");
			}

			if (entity.Oxygen + entity.Nitrogen + entity.Helium + entity.Hydrogen != 100)
			{
				isValid = false;
				AppendMessage(messages, nameof(entity.Hydrogen), "A blend that adds up to 100% is required.");
			}

			return isValid;
		}

		#endregion

		public bool Validate(DiveGasMixture entity, out IImmutableDictionary<string, IImmutableList<string>>? messages)
		{
			var propertyMessages = new Dictionary<string, IImmutableList<string>>();

			// Validate gas mixtures
			if (ValidateAir(entity, propertyMessages) && ValidateEnrichedAir(entity, propertyMessages)
				&& ValidateTrimix(entity, propertyMessages) && ValidateHeliox(entity, propertyMessages)
				&& ValidateHydrox(entity, propertyMessages) && ValidateHydreliox(entity, propertyMessages)
				&& ValidateRebreather(entity, propertyMessages) && ValidateOther(entity, propertyMessages))
			{
				messages = null;
				return true;
			}

			messages = propertyMessages.ToImmutableDictionary();
			return false;
		}
	}
}
