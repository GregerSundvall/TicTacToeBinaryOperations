
void TicTacToe()
{
    const int BOARD_SIZE = 3;
    
    static bool check_bit(int bit_string, int index)
    {
        var target_bit = (0b_0000_0001 << index);
        var result = bit_string & target_bit;
        return result != 0;
    }
    static int set_bit(int bit_string, int index)
    {
        var target_bit = (0b_0000_0001 << index);
        var result = bit_string | target_bit;
        return result;
    }
    static int clear_bit(int bit_string, int index)
    {
        var target_bit = (0b_0000_0001 << index);
        var result = bit_string & ~target_bit;
        return result;
    }

    static int position_to_index(int x, int y)
    {
        return (x * BOARD_SIZE) + y;
    }

    static bool Check_bit(int bit_string, int x, int y)
    {
        return check_bit(bit_string, position_to_index(x, y));
    }
    static int Set_bit(int bit_string, int x, int y)
    {
        return set_bit(bit_string, position_to_index(x, y));
    }
    static int Clear_bit(int bit_string, int x, int y)
    {
        return clear_bit(bit_string, position_to_index(x, y));
    }

    // is stone circle
    // is slot occupied
    bool is_circle_turn = false;
    int circle_bit_string = 0;
    int slot_bit_string = 0;

    int horizontal_scan_line = 0b_000_000_111;
    // add scanline for Vertical
    // add edge cases for diagonal
    void place_stone(int x, int y)
    {
        slot_bit_string = Set_bit(slot_bit_string, x, y);
        if (is_circle_turn)
        {
            circle_bit_string = Set_bit(circle_bit_string, x, y);
        }

        for (int index = 0; index < BOARD_SIZE; index++)
        {
            int horizontal_line = horizontal_scan_line << index;
            var placed = (horizontal_line & slot_bit_string);
            if (placed == horizontal_line)
            {
                var color = placed & circle_bit_string;
                if (color == placed)
                {
                    Console.WriteLine($"Game Won by Circle");
                    return;
                }
                else if(color == 0)
                {
                    Console.WriteLine($"Game Won by Cross");
                    return;
                }
            }
        }
        is_circle_turn = !is_circle_turn;
    }

    place_stone(0, 0);
    place_stone(1, 0);
    place_stone(0, 1);
    place_stone(1, 1);
    place_stone(0, 2);

    for (int y = 0; y < BOARD_SIZE; y++)
    {
        for (int x = 0; x < BOARD_SIZE; x++)
        {
            if(!Check_bit(slot_bit_string, x, y))
            {
                Console.Write($"Empty\t");
            }
            else
            {
                if(Check_bit(circle_bit_string, x, y))
                {
                    Console.Write($"Circle\t");
                }
                else
                {
                    Console.Write($"Cross\t");
                }
            }
        }
        Console.Write($"\n");
    }
}
