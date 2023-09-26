namespace Blog_2.ViewModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> erros) 
        {
            Data = data;
            Errors = erros;
        }

        public ResultViewModel(T data) 
        {
            Data = data;
        }

        public ResultViewModel(List<string> erros) 
        {
            Errors = erros;
        }

        public ResultViewModel(string error) 
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
