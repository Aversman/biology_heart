using System.Text.Json;

class Program {
  public static void Main() {
    string json = File.ReadAllText("input.json");
    Cell[]? cells = JsonSerializer.Deserialize<Cell[]>(json);
    if (cells == null) {
      throw new CellException("input data was not written");
    }
    // Входные данные, длина основного массива = количествку тактов
    int[][] data = {
      new int[] {0, 0, 0, 4, 0, 0, 2},
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {4, 0, 0, 0, 0, 4, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0}
    };
    Heart heart = new Heart(cells, data);
    heart.ExecProcess();
  }
}