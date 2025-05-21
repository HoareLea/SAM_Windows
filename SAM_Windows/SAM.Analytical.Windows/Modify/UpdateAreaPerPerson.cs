namespace SAM.Analytical.Windows
{
    public static partial class Modify
    {
        public static void UpdateAreaPerPerson(this Space space)
        {
            if(space == null)
            {
                return;
            }

            if(!space.TryGetValue(SpaceParameter.Occupancy, out double occupancy))
            {
                return;
            }

            space.UpdateOccupancy(occupancy);
        }

    }
}