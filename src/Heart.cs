class HeartException : Exception {
  public HeartException(string message) : base(message) {
    Console.WriteLine(message);
  }
}
sealed class Heart {
  // массив клеток
  Cell[] cells;
  // входные данные
  int[][] data;
  public Heart(Cell[] cells, int[][] data) {
    this.cells = cells;
    this.data = data;
  }
  void UpdateStateCells(int[] input) {
    int[] currentStates = new int[cells.Length];
    for (int i = 0; i < cells.Length; i++) {
      currentStates[i] = cells[i].State;
    }

    for (int i = 0; i < cells.Length; i++) {
      cells[i].ChangeState(input[i]);

      int[]? connectors = cells[i].Connectors;
      if (connectors == null) throw new HeartException("Connectors mustn't be null");
      
      if (currentStates[i] == cells[i].MaxState) {
        for (int j = 0; j < connectors.Length; j++) {
          if (cells[connectors[j]].State == 0) {
            cells[connectors[j]].ChangeState(cells[connectors[j]].MaxState);
          }
        }
      }

      if (currentStates[i] == cells[i].State) {
        cells[i].DecrementState();
      }
    }
  }
  public void ExecProcess() {
    foreach (var input in data) {
      UpdateStateCells(input);
      string output = "";
      foreach (var cell in cells) {
        if (cell.State == cell.MaxState) {
          output += "* ";
        }else {
          output += $"{cell.State} ";
        }
      }
      Console.WriteLine(output);
      output = "";
    }
  }
}