public interface IRepository {
    public void CreateData();
    public void UpdateData(int primaryKey);
    public Dictionary<int,string> FetchData();
}