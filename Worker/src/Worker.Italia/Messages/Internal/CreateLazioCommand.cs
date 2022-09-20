namespace Worker.Italia.Messages.Internal
{
    public class CreateLazioCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public record CreateLazioCommandImmutable(
        string Name,
        string LastName
    );
}