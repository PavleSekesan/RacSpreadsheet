<h2> RacSpreadsheet </h2>

  A clone of popular spreadsheet programs such as Excel or Google Sheets
  
<h3> Installation </h3>

  The application can be installed by: <br>
  1. Downloading [Microsoft Visual Studio](https://visualstudio.microsoft.com/free-developer-offers/) <br>
  2. Downloading or cloning the source code from this repository <br>
  3. Opening the .sln file with Visual Studio <br>
  4. Building the solution in Visual Studio ([image](https://imgur.com/a/yiqZG2K)) <br>
  5. Running the .exe file located in RacSpreadsheet/bin/Release or executing it direcly from the Visual Studio .sln file

<h3> Currently implemented features </h3>

  <b>- File import and export system:</b> Files can be imported and exported in an xml file format <br>
  ![import](https://i.imgur.com/vk67QEY.png)
  ![export](https://user-images.githubusercontent.com/48137570/115129152-ad5edd00-9fe3-11eb-8666-d2061d72e709.png) <br>
  <b>- Cell data input:</b> User data can be inputted by selecting a cell and typing the data in <br>
  ![cellinput](https://user-images.githubusercontent.com/48137570/115129228-56a5d300-9fe4-11eb-95dd-76c364a09919.gif) <br>
  <b>- Cell function calculation:</b> Various functions (currently only SUM and AVG) can be calculated by selecting a cell and typing the desired function into the textbox (the function syntax follows Google Sheets conventions). The output of the function is shown in the selected cell. Example: SUM(AVG(A1,A2),46) calculates the average of the values in cells A1 and A2 and adds 46 <br>
  ![functioncalculation](https://user-images.githubusercontent.com/48137570/115129318-1c890100-9fe5-11eb-863b-df0be85dba17.gif) <br>
  <b>- Dynamic cell update:</b> When some cell changes its value, all other cells that depended on its value are recalculated automatically <br>
  ![cellupdate](https://user-images.githubusercontent.com/48137570/115129370-7db0d480-9fe5-11eb-8192-8e539c8aa681.gif) <br>

<h3> Features to be implemented </h3>

  <b>- Function argument input by selecting cells</b> <br> 
  <b>- Multiple selected cell clear</b> <br>
  <b>- Cell autofill</b> <br>
