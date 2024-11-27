namespace RRMS
{
    public class EntityEventArgs: EventArgs
    {
        public string StringId { get; set; } = default!;

        public byte ByteId { get; set; } =0;
        public EntityTypes Entity { get; set; } = EntityTypes.None;
        
        public new static EntityEventArgs Empty => new EntityEventArgs();
    }
}