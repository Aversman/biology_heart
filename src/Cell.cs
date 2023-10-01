class CellException : Exception {
  public CellException(string message) : base(message) {
    Console.WriteLine(message);
  }
}
sealed class Cell {
  public int MaxState { get; set; }
  public int State { get; set; }
  public int[]? Connectors { get; set; }
  public void ChangeState(int state = 0) {
    if (state >= MaxState) {
      State = MaxState;
      return;
    }
    if (state > State) {
      State = state;
    }
  }
  public void DecrementState() {
    if (State > 0)
      State--;
    else
      State = 0;
  }
}