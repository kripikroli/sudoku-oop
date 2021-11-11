# Sudoku OOP C#

An OOP/SOLID implementation of sudoku puzzle game.

# Usage
1. Download VisualStudio (2015 version up).
2. Download the repository.
3. Open the .sln file using Visual Studio and rebuild the projct.
4. Make sure to update the file directories of the puzzle

There's a lot of open posibilities to play around with the game and how it can be implemented in SOLID/OO principles. 

PS: I wil try to refactor this approach next time for some more clean coding and fixing of noisy codes.

## 1. How Sudoku works?

Standard sudoku puzzle involves a 9×9 grid of squares subdivided into 3×3 boxes. 

<img width=“450” src="https://github.com/kripikroli/sudoku-oop/blob/master/images/1.png">

In total there are 81 squares on a sudoku grid and when the puzzle is completed each square will contain exactly one number.

## 2. Know the rules

Sudoku is a puzzle based on a small number of very simple rules:

1. Every square has to contain a single number
2. Only the numbers from 1 through to 9 can be used
3. Each 3×3 box can only contain each number from 1 to 9 once
4. Each vertical column can only contain each number from 1 to 9 once
5. Each horizontal row can only contain each number from 1 to 9 once
6. Once the puzzle is solved, this means that every row, column, and 3×3 box will contain every number from 1 to 9 exactly once. 

In other words, no number can be repeated in any 3×3 box, row, or column. 

## 3. Find squares that can only be one number

When you start a new sudoku puzzle, some squares will already be filled with numbers. 

Based on how difficult the puzzle is, these numbers will ‘lock in’ specific numbers to specific squares. That is, squares where only one number can go without breaking any rules. 

For instance, only the number 2 can go into the square highlighted below.

<img width=“450” src="https://github.com/kripikroli/sudoku-oop/blob/master/images/2.png">

The numbers 1, 8, and 9 cannot fit into the highlighted square as these numbers already appear in the box. The numbers 3 and 5 cannot fit as they already appear in the same column as the highlighted square. Lastly, the numbers 4, 6, and 7 cannot fit as they already appear in the same row as the highlighted square.

This means that the only number left that can fit into this square is the number 2.

## 4. Use the numbers you fill in to reveal more squares

As you start filling in squares that can only be one number, you’ll be adding more numbers to the grid which start to help ‘lock in’ additional numbers to additional squares.

For instance, when we added the 2 to the bottom left 9×9 box in step 3, we also revealed the location that the 2 in the top left box must appear in the bottom right cell highlighted below.

<img width=“450” src="https://github.com/kripikroli/sudoku-oop/blob/master/images/3.png">

This is because the 2 we added in step 3 rules out the 2 from appearing in the middle column of the box. Likewise, the two given 2s in top middle and right boxes also rule out the first two rows of the top left box from containing a 2. 

This only leaves the bottom right cell of the top left box available for the 2.

Note: Not every time you add a new number to the grid will reveal a cell. The harder the puzzle, the more numbers you’ll have to add until you start uncovering new cells.

## 5. Pencil in candidates

Unless you’re completing an easy sudoku grid designed for beginners, you’ll soon run out of possible numbers you can ‘lock in’ for certain. 

When you get to this stage, it’s time to start pencilling in possible candidates for various cells. 

This is where you use small ‘pencil marks’ to list all the possible numbers a cell could contain based on the information you currently have. 

Instead of focusing on adding all the possible numbers to every empty cell, it’s easier and quicker to focus on certain cells and numbers at a time. 

For instance, going back to the example from before, we can see that adding in the pencil marks for the number 4 in the three left boxes has helped reveal the location of one of the 4s. 

The existing 4s in the grid have ruled out all of the cells in the three left boxes except for the ones we’ve added pencil marked 4s to, as highlighted below.

<img width=“450” src="https://github.com/kripikroli/sudoku-oop/blob/master/images/4.png">

Looking at these possible locations for the 4s in these three boxes, you might have already noticed that there is only one possible location in column three. 

As column three, like every column, must contain the number 4 exactly once, and this is the only cell in column three that can contain a 4, we know through deduction that the 4 must appear in this cell. 

<img width=“450” src="https://github.com/kripikroli/sudoku-oop/blob/master/images/5.png">

## 6. Repeat until you’ve solved the puzzle

All you have to do is repeat these steps until you have filled in all of the cells in the grid. 






