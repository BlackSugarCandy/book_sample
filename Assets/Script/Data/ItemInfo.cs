using Boomlagoon.JSON;

public class ItemInfo {
	public int item_info_id;
	public string name;
	public int price;
	public string payment_method;
	public string description;

	public ItemInfo(JSONObject obj)
	{
		item_info_id = (int)obj["item_info_id"].Number;
		name = obj["name"].Str;
		price = (int)obj["price"].Number;
		payment_method = obj["payment_method"].Str;
		description = obj["description"].Str;
	}
}
