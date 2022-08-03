using Buddies.Logs.Abstractions.Entities;
using Buddies.Logs.Abstractions.Enums;
using System.Collections.Immutable;

namespace Buddies.Logs.Validators.Validators
{
	internal class DiveGasMixtureValidator : IEntityValidator<DiveGasMixture>
	{
		public bool Validate(DiveGasMixture entity, out IImmutableDictionary<string, IImmutableList<string>>? messages)
		{
			var propertyMessages = new Dictionary<string, IImmutableList<string>>();

			void AppendMessage(string property, string message)
			{
				if (!propertyMessages!.ContainsKey(property))
				{
					propertyMessages.Add(property, ImmutableList.Create(message));
					return;
				}

				propertyMessages[property] = propertyMessages[property].Add(message);
			}

			// Validate gas mixture blends
			switch (entity.GasMixtureType)
			{
				// Air
				case GasMixtureType.Air when entity.Oxygen != 21:
					AppendMessage(nameof(entity.Oxygen), "Air needs to be composed of 21% Oxygen.");
					break;
				case GasMixtureType.Air when entity.Nitrogen != 79:
					AppendMessage(nameof(entity.Oxygen), "Air needs to be composed of 79% Nitrogen.");
					break;
				case GasMixtureType.Air when entity.Helium > 0:
					AppendMessage(nameof(entity.Helium), "Air cannot be blended with Helium.");
					break;
				case GasMixtureType.Air when entity.Hydrogen > 0:
					AppendMessage(nameof(entity.Hydrogen), "Air cannot be blended with Hydrogen.");
					break;

				// EANx
				case GasMixtureType.Enriched when entity.Oxygen < 21:
					AppendMessage(nameof(entity.Oxygen), "Enriched Air (EANx) needs a minimum of 22% oxygen.");
					break;
				case GasMixtureType.Enriched when entity.Oxygen > 40:
					AppendMessage(nameof(entity.Oxygen), "Enriched Air (EANx) cannot exceed 40% oxygen.");
					break;
				case GasMixtureType.Enriched when entity.Helium > 0:
					AppendMessage(nameof(entity.Helium), "Enriched Air (EANx) cannot be blended with Helium.");
					break;
				case GasMixtureType.Enriched when entity.Hydrogen > 0:
					AppendMessage(nameof(entity.Hydrogen), "Enriched Air (EANx) cannot be blended with Hydrogen.");
					break;
				case GasMixtureType.Enriched when entity.Oxygen + entity.Nitrogen != 100:
					AppendMessage(nameof(entity.Nitrogen), "Enriched Air (EANx) requires a blend that adds up to 100%.");
					break;

				// Trimix
				case GasMixtureType.Trimix when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Trimix needs to be blended with Oxygen.");
					break;
				case GasMixtureType.Trimix when entity.Nitrogen == 0:
					AppendMessage(nameof(entity.Nitrogen), "Trimix needs to be blended with Nitrogen.");
					break;
				case GasMixtureType.Trimix when entity.Helium == 0:
					AppendMessage(nameof(entity.Helium), "Trimix needs to be blended with Helium.");
					break;
				case GasMixtureType.Trimix when entity.Hydrogen > 0:
					AppendMessage(nameof(entity.Hydrogen), "Trimix cannot be blended with Hydrogen.");
					break;
				case GasMixtureType.Trimix when entity.Oxygen + entity.Nitrogen + entity.Helium != 100:
					AppendMessage(nameof(entity.Helium), "Trimix requires a blend that adds up to 100%.");
					break;

				// Heliox
				case GasMixtureType.Heliox when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Heliox needs to be blended with Oxygen.");
					break;
				case GasMixtureType.Heliox when entity.Nitrogen > 0:
					AppendMessage(nameof(entity.Nitrogen), "Heliox cannot be blended with Nitrogen.");
					break;
				case GasMixtureType.Heliox when entity.Helium == 0:
					AppendMessage(nameof(entity.Helium), "Heliox needs to be blended with Helium.");
					break;
				case GasMixtureType.Heliox when entity.Hydrogen > 0:
					AppendMessage(nameof(entity.Hydrogen), "Heliox cannot be blended with Hydrogen.");
					break;
				case GasMixtureType.Heliox when entity.Oxygen + entity.Helium != 100:
					AppendMessage(nameof(entity.Helium), "Heliox requires a blend that adds up to 100%.");
					break;

				// Hydrox
				case GasMixtureType.Hydrox when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Hydrox needs to be blended with Oxygen.");
					break;
				case GasMixtureType.Hydrox when entity.Nitrogen > 0:
					AppendMessage(nameof(entity.Nitrogen), "Hydrox cannot be blended with Nitrogen.");
					break;
				case GasMixtureType.Hydrox when entity.Helium > 0:
					AppendMessage(nameof(entity.Helium), "Hydrox cannot be blended with Helium.");
					break;
				case GasMixtureType.Hydrox when entity.Hydrogen == 0:
					AppendMessage(nameof(entity.Hydrogen), "Hydrox needs to be blended with Hydrogen.");
					break;
				case GasMixtureType.Heliox when entity.Oxygen + entity.Hydrogen != 100:
					AppendMessage(nameof(entity.Hydrogen), "Hydrox requires a blend that adds up to 100%.");
					break;

				// Hydreliox
				case GasMixtureType.Hydreliox when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Hydreliox needs to be blended with Oxygen.");
					break;
				case GasMixtureType.Hydreliox when entity.Nitrogen > 0:
					AppendMessage(nameof(entity.Nitrogen), "Hydreliox cannot be blended with Nitrogen.");
					break;
				case GasMixtureType.Hydreliox when entity.Helium == 0:
					AppendMessage(nameof(entity.Helium), "Hydreliox needs be blended with Helium.");
					break;
				case GasMixtureType.Hydreliox when entity.Hydrogen == 0:
					AppendMessage(nameof(entity.Hydrogen), "Hydreliox needs to be blended with Hydrogen.");
					break;
				case GasMixtureType.Hydreliox when entity.Oxygen + entity.Helium + entity.Hydrogen != 100:
					AppendMessage(nameof(entity.Hydrogen), "Hydreliox requires a blend that adds up to 100%.");
					break;

				// Rebreather
				case GasMixtureType.Rebreather when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Rebreather needs to be blended with Oxygen.");
					break;
				case GasMixtureType.Rebreather when entity.Oxygen + entity.Nitrogen + entity.Helium + entity.Hydrogen != 100:
					AppendMessage(nameof(entity.Hydrogen), "Rebreather requires a blend that adds up to 100%.");
					break;

				// Other
				case GasMixtureType.Rebreather when entity.Oxygen == 0:
					AppendMessage(nameof(entity.Oxygen), "Oxygen is required.");
					break;
				case GasMixtureType.Rebreather when entity.Oxygen + entity.Nitrogen + entity.Helium + entity.Hydrogen != 100:
					AppendMessage(nameof(entity.Hydrogen), "A blend that adds up to 100% is required.");
					break;

				// Success
				default:
					messages = null;
					return true;
			}

			messages = propertyMessages.ToImmutableDictionary();
			return false;
		}
	}
}
