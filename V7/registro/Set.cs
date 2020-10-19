namespace registro
{

    class Set
    {

        private Datos[][] buckets = new Datos[20][];

        public Set(){

            for (int i = 0; i < buckets.Length; i++)
            {

                buckets[i] = new Datos[3];
                
            }

        }

        public bool Add(Datos data){

            if (Contains(data))
            {
                
                return false;

            }

            bool filledBucket = false;
            int bucketIndex = data.GetHashCode() % buckets.Length;
            Datos[] bucket = buckets[bucketIndex];

            for (int i = 0; i < bucket.Length; i++)
            {

                if (bucket[i] == null)
                {

                    bucket[i] = data;
                    filledBucket = true;
                    break;
                    
                }
                
            }

            if (!filledBucket)
            {

                ExpandBucket(bucketIndex);
                buckets[bucketIndex][bucket.Length] = data;
                
            }

            return true;

        }

        private void ExpandBucket(int bucketIndex){

            int oldLenght = buckets[bucketIndex].Length;
            int newLenght = (int)(oldLenght * 1.5);

            Datos[] newBucket = new Datos[newLenght];

            for (int i = 0; i < oldLenght; i++)
            {
                
                newBucket[i] = buckets[bucketIndex][i];

            }

        }

        public bool Contains(Datos data){

            int bucketsIndex = data.GetHashCode() % buckets.Length;

            Datos[] bucket = buckets[bucketsIndex];
            for (int i = 0; i < bucket.Length; i++)
            {

                if (data.Equals(bucket[i]))
                {

                    return true;
                    
                }
                
            }

            return false;

        }

        public bool Remove(in Datos toRemove){

            return false;

        }
        
    }
    
}