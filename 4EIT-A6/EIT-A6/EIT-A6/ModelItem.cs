namespace EIT_A6
{
    internal class ModelItem
    {
        internal int ModelId;
        internal string Naziv;
        private int modelId;
        private string naziv;

        public ModelItem(int modelId, string naziv)
        {
            this.modelId = modelId;
            this.naziv = naziv;
        }
    }
}