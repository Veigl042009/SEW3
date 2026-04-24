#include<stdio.h>

int main(){
    float celcius;
    printf("Gib die Grad in Celcius ein:");
    scanf("%f", &celcius);

    float fahrenheit;
    fahrenheit = (celcius*9)/5+32;
    printf("Fahrenheit sind %f", fahrenheit);

    return 0;

}