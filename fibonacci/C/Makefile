CC = gcc
CFLAGS = -O2 -s -DNDEBUG

main: main.c fibo.o fibo_iter.o
	$(CC)  $(CFLAGS) -o c_fibo.exe main.c fibo.o fibo_iter.o

fibo.o: fibo.c
	$(CC) $(CFLAGS) fibo.c -c

fibo_iter.o: fibo_iter.c
	$(CC) $(CFLAGS) fibo_iter.c -c

.PHONY: clean

clean:
	rm -rf *.o
