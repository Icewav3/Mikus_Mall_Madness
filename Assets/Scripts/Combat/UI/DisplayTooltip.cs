using TMPro;

using UnityEngine;

public class DisplayTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _descriptionText;
	public TextMeshProUGUI DescriptionText => _descriptionText;

	[SerializeField]
	private TextMeshProUGUI _staminaCostText;
	public TextMeshProUGUI StaminaCostText => _staminaCostText;
}
