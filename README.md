# Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave
A request to pre-set two registers starting at 40001 to 0000H, 00001H, …., and 0009H, in slave device 1. The first register is the LED1 state, the second register is the LED2 state.
## Request frame of Master
01 10 00 00 00 02 04 00 00 00 01 32 6F
|Field Name|	Value (Hex)|
|---------|----------|
|Slave Address|	01|
|Function|	10|
|Starting Address Hi|	00|
|Starting Address Lo|	00|
|Number of registers Hi|	00|
|Number of registers Lo|	02|
|Byte count|	04|
|Data Hi|	00|
|Data Lo|	00|
|Data Hi|	00|
|Data Lo|	01|
|CRC Hi|	32|
|CRC Lo|	6F|

## Response frame of Slave
01 10 00 00 00 02 41 C8
|Field Name|	Value (Hex)|
|------|---------|
|Slave Address|	01|
|Function|	10|
|Starting Address Hi|	00|
|Starting Address Lo	|00|
|Number of registers Hi|	00|
|Number of registers Lo|	02|
|CRC Hi|	41|
CRC Lo	|C8|

## Library
[modbusSlave.c](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/blob/master/modbus_STM32_Slave/MDK-ARM/modbusSlave.c)
[modbusSlave.h](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/blob/master/modbus_STM32_Slave/MDK-ARM/modbusSlave.h)
[modbus_crc.c](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/blob/master/modbus_STM32_Slave/MDK-ARM/modbus_crc.c)
[modbus_crc.h](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/blob/master/modbus_STM32_Slave/MDK-ARM/modbus_crc.h)

How to use this Library:
  * Include "modbusSlave.h" and create global variables
  ```
#include "modbusSlave.h"

uint8_t RxData[256];
uint8_t TxData[256];
uint16_t Holding_Registers_Data[50];
  ```
  * Write interrupt function
    ```
    void HAL_UARTEx_RxEventCallback(UART_HandleTypeDef *huart, uint16_t Size)
    {
      if(huart->Instance == huart2.Instance) // check interrupt of serial port 2
      {
        uint16_t size = sizeof(RxData) / sizeof(RxData[0]);
        uint16_t crc = crc16(RxData, size);
        uint8_t crcLo = crc&0xFF;   // CRC LOW
        uint8_t crcHi = (crc>>8)&0xFF;  // CRC HIGH
        if((RxData[size-1] == crcLo) && (RxData[size-2] == crcHi)) // CRC check
        {
          if (RxData[0] == SLAVE_ID)
          {
            switch (RxData[1])
            {
              case 0x03:
              readHoldingRegs();
    						
              break;
              case 0x04:
              readInputRegs();
    						
              break;
              case 0x01:
              readCoils();
    						
              break;
              case 0x02:
              readInputs();
    						
              break;
              case 0x06:
              writeSingleReg();
    						
              break;
              case 0x10:
              writeHoldingRegs();
    						
              if(Holding_Registers_Data[0]== 1) HAL_GPIO_WritePin(GPIOB, GPIO_PIN_6, 1);
              else if(Holding_Registers_Data[0] == 0) HAL_GPIO_WritePin(GPIOB, GPIO_PIN_6, 0);
    						
              if(Holding_Registers_Data[1] == 1) HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, 1);
              else if(Holding_Registers_Data[1] == 0) HAL_GPIO_WritePin(GPIOB, GPIO_PIN_7, 0);
    						
              break;
              default:
            	modbusException(ILLEGAL_FUNCTION);
    						
              break;
              }
            }
          }
        else modbusException(ILLEGAL_FUNCTION);
        HAL_UARTEx_ReceiveToIdle_IT(&huart2, RxData, 256);
      }
    }		
    ```
## Demo
[Source code](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/blob/master/modbus_STM32_Slave/Core/Src/main.c)

![image](https://github.com/VanHuyTran24/Modbus-RTU-Preset-Multiple-Registers-STM32-As-Slave/assets/166670555/32bc2d2d-862d-4267-a5ce-4c9fea6d297c)



