public interface IValidation {
    public int[] GetLocator(int id);
    public void CheckRedundancyData<T1,T2>(T1 param1, T2 param2);
}