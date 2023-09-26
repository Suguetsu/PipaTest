# PipaTest/ *Md Estudo*


##  Teste de admição _pipa studio_.

### Fui submetido a esse teste, para avalição de ingresso.

###### A **entrevista** foi __bem__ _dinâmica_.
 
 **Despois** de __algumas__ horas eu consegui _resolver_ o desafio
 * Como foi.
 
 1. Foi interessante 
    * não, não foi, foi frunstrante.
 3. engajante
     * Meus dedos grudaram no teclado
 5. mas o fim foi triste
     * Ri alto, mas de nervoso
 7. kkkk

![Minha cara](https://www.kambe-events.co.uk/wp-content/uploads/2013/11/Sad-Clown.jpg)

[POrtfólio](https://img.freepik.com/vetores-gratis/glitch-error-404-page_23-2148105404.jpg?w=2000)

[![Linkando Imagem](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRK76HKlaQ4vmpNk2zaAr9CfX05ViZRRhv2i4Rt7mue8_slGGTiIVBldhqPy44XQ0QBl_w&usqp=CAU)](https://media.gazetadopovo.com.br/rodrigo-constantino/2019/04/lula-preso-1-1-aa1c8a08.jpg)

### Código do gitHub MarkDown

```c++
//int Soma(int a, int b)=> return a+b;

/ C++ code
//

#include<Servo.h>

Servo _0motor;
Servo _1motor;
Servo _2motor;
Servo _3motor;


int pot0 = A0;
int pot1 = A1;
int pot2 = A2;
int pot3 = A3;

int aux =0.1f;


int angulo0=90;
int angulo1=90;
int angulo2=90;
int angulo3=90;

void setup() // like void start c# // constructor java
{
  
  
  _0motor.attach(8);
  _1motor.attach(9);
  _2motor.attach(10);
  _3motor.attach(11);
  
}

void loop() // like void Update c# // main java
{
  angulo0=analogRead(pot0);
  angulo1=analogRead(pot1);
  angulo2=analogRead(pot2);
  angulo3=analogRead(pot3);
  
  
   if(angulo0 > aux){
    
   
    UpdateMotor(0,Angulo(angulo0));
    

  }
  
  
   if(angulo1 > aux){
    
    
  UpdateMotor(1,Angulo(angulo1));
    

  }
  
   if(angulo2 > aux){
    
   
    UpdateMotor(2,Angulo(angulo2));
    

  }
  
  
    if(angulo3 > aux){
    
  
   UpdateMotor(3,Angulo(angulo3));
    

  }
  
 
  
    
  
}


int Angulo(int b){ return map(b,0,1018,0,180);}
void UpdateMotor(int index, int a){ 
  
  
  switch(index){
    
    	case 0:
      _0motor.write(a);
     
    break;
    
    	case 1:
        _1motor.write(a);
    
    break;
    
    	case 2:
        _2motor.write(a);
    
    break;
    
    	case 3:
        _3motor.write(a);
    
    break;
    
    	default:
      
        _0motor.write(aux);
        _1motor.write(aux);
        _2motor.write(aux);
        _3motor.write(aux);
    
    break;
    
    
  }

}

``` 

### Lista de vida
- [x] Ser irresponsável aos 18 anos
- [x] Usar o cartão de crédito como se não houvesse amanhã
- [X] Fazer EMPRÉSTIMOSSSSS
- [x] Se arrepender
- [x] Tomar vergonha na cara
- [x] Estudar
- [ ] Ficar rico
  
