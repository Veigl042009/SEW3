#include<stdio.h>

    void doSomething(int a, int b){
        a = 42;
        b = 67;
    }

    void swap(int* ptrA, int* ptrB){
        int tmp = *ptrA;
        *ptrA = *ptrB;
        *ptrB = tmp;
    }
    
    void arrayAsParameter(int* array) {

    }

    void arrayAsParameter2(int array[] ){

    }

int main(){
    char a = 42;     // char --> 1 byte --> Bit
    char b = 67;
    char arry[6] = {1, 2, 3, 4, 5, 6};  // 6 byte
    int f;          // 4 byte

    a = 42;
    char* p = &a;              // Zeiger auf einem char (Zeiger auf einem Scpeicherplatz)
    printf("Adresse von a: %p\n", p);
    p = &b;
    printf("Adresse von b: %p\n", p);
    p = arry;
    printf("Adresse von b: %p\n", p);

    char x = *p;    // *p greife ich auf einem Scpeicherplatz
    printf("%d\n", x);

    x = *(p + 2);      // Adresse vom Beginn des Arrys + 2 Byte;
    printf("%d\n", x);

     x = *(p + 7);      
    printf("%d\n", x);

    int c = 5;
    int d = 8;
    doSomething(c, d);
    printf("Wert von c: %d\n", c);
    printf("Wert von d: %d\n", d);

    swap(&c , &d);
    printf("Wert von c: %d\n", c);
    printf("Wert von d: %d\n", d);


    int input;
    //scanf("%d", &input);        // Argument input wird bei Call-by-reference (Adresse wird übergeben)

    int numbers[4] = {22, 33, 44, 55};
    printf("%p", numbers);

    arrayAsParameter(numbers);
    arrayAsParameter2(numbers);

    return 0;
}