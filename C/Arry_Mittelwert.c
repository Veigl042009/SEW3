#include<stdio.h>
int main(){
    double werte[10];
    double sum = 0.0;
        for (int i = 0; i < 10; i++) {
        printf("Wert %d: ", i + 1);
        scanf("%lf", &werte[i]);
        sum += werte[i];
    }
 
    double mittelwert = sum / 10.0;
    printf("Mittelwert: %.2f\n", mittelwert);
    return 0;

}