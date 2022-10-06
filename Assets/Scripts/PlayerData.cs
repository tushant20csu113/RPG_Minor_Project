public class PlayerData
{
    public float[] Position { get; set; }

    public static PlayerData FromPlayer(Player player)
    {
        return new PlayerData
        {
        
            Position = new float[]
            {
                player.transform.position.x,
                player.transform.position.y,
                player.transform.position.z
            }
        };
    }
}
