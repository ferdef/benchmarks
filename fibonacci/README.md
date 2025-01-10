# Scenario

### This is a Recursive Fibonacci for the 50th element

- Compiled if possible
- Using Release profile if available
- Used `time` in Linux or language time functions

# Current Results (Ordered by time asc):

## WSL Ubuntu 22.04

|Language|Version|CPU|Time|
|---|---|---|---|
|C++|g++ 11.4.0|AMD Ryzen 7 PRO 8840U|00:10.329|
|C++|g++ 11.4.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:12.440|
|C|gcc 11.4.0|AMD Ryzen 7 PRO 8840U|00:16.023|
|C|gcc 11.4.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:20.615|
|Zig|0.13|AMD Ryzen 7 PRO 8840U|0:00:23.592|
|Rust|1.83.0|AMD Ryzen 7 PRO 8840U|0:00:25.331|
|Mojo|24.6.0|AMD Ryzen 7 PRO 8840U|00:26.127|
|Zig|0.13|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|0:00:28.162|
|Rust|1.83.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|0:00:28.190|
|Mojo|24.6.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:31.180|
|Go|1.18.1|AMD Ryzen 7 PRO 8840U|00:41.425|
|Go|1.18.1|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:51.668|
|NodeJS|20.11.1|AMD Ryzen 7 PRO 8840U|01:41.710|
|Python|3.10.12|AMD Ryzen 7 PRO 8840U|Could not finish|

## Windows 11

|Language|Version|CPU|Time|
|---|---|---|---|
|C++|g++ 13.2.0|AMD Ryzen 7 PRO 8840U|00:09.771|
|C++|g++ 13.2.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:12.709|
|C|gcc 13.2.0|AMD Ryzen 7 PRO 8840U|00:15.281|
|C|cl 19.41.34|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:20.595|
|C|gcc 13.2.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:20.820|
|Zig|0.13|AMD Ryzen 7 PRO 8840U|00:26.191|
|Rust|1.83.0|AMD Ryzen 7 PRO 8840U|00:26.337|
|C++|cl 19.41.34|AMD Ryzen 7 PRO 8840U|00:27.799|
|Rust|1.83.0|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:31.010|
|Zig|0.13|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:31.131|
|C++|cl 19.41.34|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:32.568|
|C|cl 19.41.34|AMD Ryzen 7 PRO 8840U|00:44.913|
|Go|1.23.2|AMD Ryzen 7 PRO 8840U|00:46.941|
|Go|1.23.4|<span style="color:lightblue">AMD Ryzen 7 5800H</span>|00:55.064|
