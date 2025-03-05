namespace GameCharacterService.Entities
{
    public class GameCharacter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
    }
}
