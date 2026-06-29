using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType {Melee, Range, Glove, Shoe, Heal}

	public  ItemType itemType;//아이템 종류
	public int itemId;//아이템 고유번호
	public string itemName;//아이템 이름(UI표시)
	public string itemDesc;//아이템 설명(UI표시)
	public Sprite itemIcon;//아이템 아이콘(UI표시)
	
	[Header("# Level Data")]
	public float baseDamage;//0레벨 기본데미지
	public int baseCount;//기본 갯수(근접은 칼날수, 원거리는 관통수)
	public float[] damages;//레벨별 데미지 증가량
	public int[] counts;//레벨별 갯수 증가량
	
	[Header("# Weapon")]
	public GameObject projectile;// 무기가 사용할 투사체 프리펩

}
