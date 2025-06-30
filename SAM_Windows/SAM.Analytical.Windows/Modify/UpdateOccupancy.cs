namespace SAM.Analytical.Windows
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates Space occupancy and InternalCondition AreaPerPerson parameter 
        /// </summary>
        /// <param name="space">Space</param>
        /// <param name="occupancy">Occupancy</param>
        public static void UpdateOccupancy(this Space space, double occupancy)
        {
            if(space == null || occupancy < 0)
            {
                return;
            }

            if (double.IsNaN(occupancy))
            {
                space.RemoveValue(SpaceParameter.Occupancy);
            }
            else
            {
                space.SetValue(SpaceParameter.Occupancy, occupancy);

                if (!double.IsNaN(occupancy) && space.TryGetValue(SpaceParameter.Area, out double area) && !double.IsNaN(area) && area > 0)
                {
                    InternalCondition internalCondition = space.InternalCondition;
                    if (internalCondition != null)
                    {
                        internalCondition.SetValue(InternalConditionParameter.AreaPerPerson, occupancy == 0 ? 0 : area / occupancy);
                        space.InternalCondition = internalCondition;
                    }
                }

            }

        }

    }
}