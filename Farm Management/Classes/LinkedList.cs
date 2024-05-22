namespace Classes.LinkedList
{
    using Classes.Vehicle;
    using Classes.Job;
    using Classes.Part;

    public class LinkedList
    {
        private Node? HeadNode;

        public LinkedList()
        {
            HeadNode = null;
        }

        public void Append(string Data)
        {
            if (HeadNode == null)
                HeadNode = new Node(Data);
            else
                HeadNode.Append(Data);
        }

        public void AppendVehicle(Vehicle VehicleData)
        {
            if (HeadNode == null)
                HeadNode = new Node(VehicleData);
            else
                HeadNode.AppendVehicle(VehicleData);
        }

        public void AppendPart(Part PartData)
        {
            if (HeadNode == null)
                HeadNode = new Node(PartData);
            else
                HeadNode.AppendPart(PartData);
        }

        public void AppendJob(Job JobData)
        {
            if (HeadNode == null)
                HeadNode = new Node(JobData);
            else
                HeadNode.AppendJob(JobData);
        }

        public void Remove(string Data)
        {
            if (HeadNode != null)
            {
                if (HeadNode.Data == Data)
                    HeadNode = HeadNode.Next;
                else
                    HeadNode.Remove(Data);
            }
        }

        public void RemoveVehicle(int VehicleID)
        {
            if (HeadNode != null)
            {
                if (HeadNode?.VehicleData?.GetVehicleID() == VehicleID)
                    HeadNode = HeadNode.Next;
                else
                    HeadNode?.RemoveVehicle(VehicleID);
            }
        }

        public void RemovePart(int PartID)
        {
            if (HeadNode != null)
            {
                if (HeadNode?.PartData?.GetPartID() == PartID)
                    HeadNode = HeadNode.Next;
                else
                    HeadNode?.RemovePart(PartID);
            }
        }

        public void RemoveJob(int JobID)
        {
            if (HeadNode != null)
            {
                if (HeadNode?.JobData?.GetJobID() == JobID)
                    HeadNode = HeadNode.Next;
                else
                    HeadNode?.RemoveJob(JobID);
            }
        }

        public int Count()
        {
            int Count = 0;
            Node? TempHeadNode = HeadNode;

            while (TempHeadNode != null)
            {
                Count++;
                TempHeadNode = TempHeadNode.Next;
            }

            return Count;
        }

        public string GetItem(int index)
        {
            int Count = 1;
            Node? TempHeadNode = HeadNode;

            if (TempHeadNode != null)
            {
                while (Count != index)
                {
                    TempHeadNode = TempHeadNode?.Next;
                    Count++;
                }
            }

            return TempHeadNode.Data;
        }

        public Job GetJob(int index)
        {
            int Count = 1;
            Node? TempHeadNode = HeadNode;

            if (TempHeadNode != null)
            {
                while (Count != index)
                {
                    TempHeadNode = TempHeadNode?.Next;
                    Count++;
                }
            }

            return TempHeadNode.JobData;
        }

        public Vehicle GetVehicle(int index)
        {
            int Count = 1;
            Node? TempHeadNode = HeadNode;

            if (TempHeadNode != null)
            {
                while (Count != index)
                {
                    TempHeadNode = TempHeadNode?.Next;
                    Count++;
                }
            }

            return TempHeadNode.VehicleData;
        }

        public Part GetPart(int index)
        {
            int Count = 1;
            Node? TempHeadNode = HeadNode;

            if (TempHeadNode != null)
            {
                while (Count != index)
                {
                    TempHeadNode = TempHeadNode?.Next;
                    Count++;
                }
            }

            return TempHeadNode.PartData;
        }
    }

    public class Node
    {
        public string? Data;
        public Vehicle? VehicleData;
        public Part? PartData;
        public Job? JobData;
        public Node? Next;

        public Node(string Data)
        {
            this.Data = Data;
            Next = null;
        }

        public Node(Vehicle VehicleData)
        {
            this.VehicleData = VehicleData;
            Next = null;
        }

        public Node(Part PartData)
        {
            this.PartData = PartData;
            Next = null;
        }

        public Node(Job JobData)
        {
            this.JobData = JobData;
            Next = null;
        }

        public void Append(string Data)
        {
            if (Next == null)
                Next = new Node(Data);
            else
                Next.Append(Data);
        }

        public void AppendVehicle(Vehicle VehicleData)
        {
            if (Next == null)
                Next = new Node(VehicleData);
            else
                Next.AppendVehicle(VehicleData);
        }

        public void AppendPart(Part PartData)
        {
            if (Next == null)
                Next = new Node(PartData);
            else
                Next.AppendPart(PartData);
        }

        public void AppendJob(Job JobData)
        {
            if (Next == null)
                Next = new Node(JobData);
            else
                Next.AppendJob(JobData);
        }

        public void Remove(string Data)
        {
            if (Next?.Data == Data)
                Next = Next.Next;
            else
                Next?.Remove(Data);
        }

        public void RemoveVehicle(int VehicleID)
        {
            if (Next?.VehicleData?.GetVehicleID() == VehicleID)
                Next = Next.Next;
            else
                Next?.RemoveVehicle(VehicleID);
        }

        public void RemovePart(int PartID)
        {
            if (Next?.PartData?.GetPartID() == PartID)
                Next = Next.Next;
            else
                Next?.RemovePart(PartID);
        }

        public void RemoveJob(int JobID)
        {
            if (Next?.JobData?.GetJobID() == JobID)
                Next = Next.Next;
            else
                Next?.RemoveJob(JobID);
        }
    }
}
