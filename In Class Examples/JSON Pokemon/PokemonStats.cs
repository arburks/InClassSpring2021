namespace JSON_Pokemon
{
    public class PokemonStats
    {
        public string height { get; set; }
        public string weight { get; set; }
        public Sprites sprites { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public string front_default { get; set; }
    }
}