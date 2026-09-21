/* USER CODE BEGIN Header */
/**
 ******************************************************************************
 * @file           : main.c
 * @brief          : Main program body
 ******************************************************************************
 * @attention
 *
 * <h2><center>&copy; Copyright (c) 2024 STMicroelectronics.
 * All rights reserved.</center></h2>
 *
 * This software component is licensed by ST under Ultimate Liberty license
 * SLA0044, the "License"; You may not use this file except in compliance with
 * the License. You may obtain a copy of the License at:
 *                             www.st.com/SLA0044
 *
 ******************************************************************************
 */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "cmsis_os.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "stdbool.h"
#include "math.h"
#include <string.h>
#include <stdio.h>
#include "CANSPI.h"
#include "ssd1306/ssd1306.h"
#include "ssd1306/ssd1306_tests.h"
#include "ssd1306/ssd1306_fonts.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */
#define CAN &hspi1
/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
ADC_HandleTypeDef hadc;

I2C_HandleTypeDef hi2c1;

SPI_HandleTypeDef hspi1;

TIM_HandleTypeDef htim14;

UART_HandleTypeDef huart2;

/* Definitions for defaultTask */
osThreadId_t defaultTaskHandle;
const osThreadAttr_t defaultTask_attributes = {
  .name = "defaultTask",
  .priority = (osPriority_t) osPriorityLow,
  .stack_size = 128 * 4
};
/* Definitions for RX_task */
osThreadId_t RX_taskHandle;
const osThreadAttr_t RX_task_attributes = {
  .name = "RX_task",
  .priority = (osPriority_t) osPriorityHigh,
  .stack_size = 128 * 4
};
/* Definitions for ADC_task */
osThreadId_t ADC_taskHandle;
const osThreadAttr_t ADC_task_attributes = {
  .name = "ADC_task",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for SteppingMotor_T */
osThreadId_t SteppingMotor_THandle;
const osThreadAttr_t SteppingMotor_T_attributes = {
  .name = "SteppingMotor_T",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for Servo_task */
osThreadId_t Servo_taskHandle;
const osThreadAttr_t Servo_task_attributes = {
  .name = "Servo_task",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for TX_task */
osThreadId_t TX_taskHandle;
const osThreadAttr_t TX_task_attributes = {
  .name = "TX_task",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for TX_TMP_task */
osThreadId_t TX_TMP_taskHandle;
const osThreadAttr_t TX_TMP_task_attributes = {
  .name = "TX_TMP_task",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for OLED_task */
osThreadId_t OLED_taskHandle;
const osThreadAttr_t OLED_task_attributes = {
  .name = "OLED_task",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for CAN_remote */
osThreadId_t CAN_remoteHandle;
const osThreadAttr_t CAN_remote_attributes = {
  .name = "CAN_remote",
  .priority = (osPriority_t) osPriorityNormal,
  .stack_size = 128 * 4
};
/* Definitions for RX_Queue */
osMessageQueueId_t RX_QueueHandle;
const osMessageQueueAttr_t RX_Queue_attributes = {
  .name = "RX_Queue"
};
/* Definitions for ADC_Queue */
osMessageQueueId_t ADC_QueueHandle;
const osMessageQueueAttr_t ADC_Queue_attributes = {
  .name = "ADC_Queue"
};
/* Definitions for TX_Sem */
osSemaphoreId_t TX_SemHandle;
const osSemaphoreAttr_t TX_Sem_attributes = {
  .name = "TX_Sem"
};
/* Definitions for CAN_Sem */
osSemaphoreId_t CAN_SemHandle;
const osSemaphoreAttr_t CAN_Sem_attributes = {
  .name = "CAN_Sem"
};
/* Definitions for ADC_Event */
osEventFlagsId_t ADC_EventHandle;
const osEventFlagsAttr_t ADC_Event_attributes = {
  .name = "ADC_Event"
};
/* USER CODE BEGIN PV */
#define EVENT_FLAG_VALUE 0x00000001U
float temp;
uint16_t periodoTMP = 1000;
uint8_t data_RX[4];
uint16_t led;
uint8_t temp_int;
uint8_t temp_decimal;
int adc_int = 0; //Controla cuantas veces ha realizado la conversion del ADC para que convierta bien los 2 canales configurados
uint8_t modo_oled = 0;
uCAN_MSG txMessage,rxMessage;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_USART2_UART_Init(void);
static void MX_ADC_Init(void);
static void MX_I2C1_Init(void);
static void MX_SPI1_Init(void);
static void MX_TIM14_Init(void);
void StartDefaultTask(void *argument);
void RX_Task(void *argument);
void ADC_Task(void *argument);
void SteppingMotor_task(void *argument);
void Servo_Task(void *argument);
void TX_Task(void *argument);
void TX_TMP_Task(void *argument);
void OLED_Task(void *argument);
void CAN_remote_task(void *argument);

/* USER CODE BEGIN PFP */
struct motor {
	uint8_t running, velocidad, periodo, direccion;// 0 izquierda...1 derecha
} motorPP;
struct servo {
	float posicion;
	uint8_t actuacion;//Modo servo
	int tiempo_ms,espera; //Tiempo espera de servo. Los valores iniciales se consideran 2s y 30 grados. (1/30=0.033)
} Servo;
struct remoto {
	uint8_t servo, rpm, tmp_ent, tmp_dec, CAN_Mode, direccion;
	bool CAN_Flag, soyA, soyB, soyAB;
} remote;
/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART2_UART_Init();
  MX_ADC_Init();
  MX_I2C1_Init();
  MX_SPI1_Init();
  MX_TIM14_Init();
  /* USER CODE BEGIN 2 */
	HAL_TIM_PWM_Start(&htim14, TIM_CHANNEL_1); // Iniciamos TIMER14 PWM
	ssd1306_Init();
	remote.CAN_Flag = false, remote.CAN_Mode = 0, remote.soyA = false, remote.soyB =
	false, remote.soyAB = false;
  /* USER CODE END 2 */

  /* Init scheduler */
  osKernelInitialize();

  /* USER CODE BEGIN RTOS_MUTEX */
	/* add mutexes, ... */
  /* USER CODE END RTOS_MUTEX */

  /* Create the semaphores(s) */
  /* creation of TX_Sem */
  TX_SemHandle = osSemaphoreNew(1, 1, &TX_Sem_attributes);

  /* creation of CAN_Sem */
  CAN_SemHandle = osSemaphoreNew(1, 1, &CAN_Sem_attributes);

  /* USER CODE BEGIN RTOS_SEMAPHORES */
	/* add semaphores, ... */
  /* USER CODE END RTOS_SEMAPHORES */

  /* USER CODE BEGIN RTOS_TIMERS */
	/* start timers, add new ones, ... */
  /* USER CODE END RTOS_TIMERS */

  /* Create the queue(s) */
  /* creation of RX_Queue */
  RX_QueueHandle = osMessageQueueNew (4, sizeof(uint8_t), &RX_Queue_attributes);

  /* creation of ADC_Queue */
  ADC_QueueHandle = osMessageQueueNew (16, sizeof(uint16_t), &ADC_Queue_attributes);

  /* USER CODE BEGIN RTOS_QUEUES */
	/* add queues, ... */
  /* USER CODE END RTOS_QUEUES */

  /* Create the thread(s) */
  /* creation of defaultTask */
  defaultTaskHandle = osThreadNew(StartDefaultTask, NULL, &defaultTask_attributes);

  /* creation of RX_task */
  RX_taskHandle = osThreadNew(RX_Task, NULL, &RX_task_attributes);

  /* creation of ADC_task */
  ADC_taskHandle = osThreadNew(ADC_Task, NULL, &ADC_task_attributes);

  /* creation of SteppingMotor_T */
  SteppingMotor_THandle = osThreadNew(SteppingMotor_task, NULL, &SteppingMotor_T_attributes);

  /* creation of Servo_task */
  Servo_taskHandle = osThreadNew(Servo_Task, NULL, &Servo_task_attributes);

  /* creation of TX_task */
  TX_taskHandle = osThreadNew(TX_Task, NULL, &TX_task_attributes);

  /* creation of TX_TMP_task */
  TX_TMP_taskHandle = osThreadNew(TX_TMP_Task, NULL, &TX_TMP_task_attributes);

  /* creation of OLED_task */
  OLED_taskHandle = osThreadNew(OLED_Task, NULL, &OLED_task_attributes);

  /* creation of CAN_remote */
  CAN_remoteHandle = osThreadNew(CAN_remote_task, NULL, &CAN_remote_attributes);

  /* USER CODE BEGIN RTOS_THREADS */
	osThreadSuspend(OLED_taskHandle);
	osThreadSuspend(TX_TMP_taskHandle);
	osThreadSuspend(SteppingMotor_THandle);
	osThreadSuspend(TX_taskHandle);
	/* add threads, ... */
  /* USER CODE END RTOS_THREADS */

  /* Create the event(s) */
  /* creation of ADC_Event */
  ADC_EventHandle = osEventFlagsNew(&ADC_Event_attributes);

  /* USER CODE BEGIN RTOS_EVENTS */
	/* add events, ... */
  /* USER CODE END RTOS_EVENTS */

  /* Start scheduler */
  osKernelStart();

  /* We should never get here as control is now taken by the scheduler */
  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
	while (1) {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
	}
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI|RCC_OSCILLATORTYPE_HSI14;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSI14State = RCC_HSI14_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.HSI14CalibrationValue = 16;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL6;
  RCC_OscInitStruct.PLL.PREDIV = RCC_PREDIV_DIV1;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_1) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_I2C1;
  PeriphClkInit.I2c1ClockSelection = RCC_I2C1CLKSOURCE_HSI;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief ADC Initialization Function
  * @param None
  * @retval None
  */
static void MX_ADC_Init(void)
{

  /* USER CODE BEGIN ADC_Init 0 */

  /* USER CODE END ADC_Init 0 */

  ADC_ChannelConfTypeDef sConfig = {0};

  /* USER CODE BEGIN ADC_Init 1 */

  /* USER CODE END ADC_Init 1 */
  /** Configure the global features of the ADC (Clock, Resolution, Data Alignment and number of conversion)
  */
  hadc.Instance = ADC1;
  hadc.Init.ClockPrescaler = ADC_CLOCK_ASYNC_DIV1;
  hadc.Init.Resolution = ADC_RESOLUTION_12B;
  hadc.Init.DataAlign = ADC_DATAALIGN_RIGHT;
  hadc.Init.ScanConvMode = ADC_SCAN_DIRECTION_FORWARD;
  hadc.Init.EOCSelection = ADC_EOC_SINGLE_CONV;
  hadc.Init.LowPowerAutoWait = DISABLE;
  hadc.Init.LowPowerAutoPowerOff = DISABLE;
  hadc.Init.ContinuousConvMode = ENABLE;
  hadc.Init.DiscontinuousConvMode = DISABLE;
  hadc.Init.ExternalTrigConv = ADC_SOFTWARE_START;
  hadc.Init.ExternalTrigConvEdge = ADC_EXTERNALTRIGCONVEDGE_NONE;
  hadc.Init.DMAContinuousRequests = DISABLE;
  hadc.Init.Overrun = ADC_OVR_DATA_PRESERVED;
  if (HAL_ADC_Init(&hadc) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure for the selected ADC regular channel to be converted.
  */
  sConfig.Channel = ADC_CHANNEL_0;
  sConfig.Rank = ADC_RANK_CHANNEL_NUMBER;
  sConfig.SamplingTime = ADC_SAMPLETIME_239CYCLES_5;
  if (HAL_ADC_ConfigChannel(&hadc, &sConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure for the selected ADC regular channel to be converted.
  */
  sConfig.Channel = ADC_CHANNEL_11;
  if (HAL_ADC_ConfigChannel(&hadc, &sConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN ADC_Init 2 */

  /* USER CODE END ADC_Init 2 */

}

/**
  * @brief I2C1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_I2C1_Init(void)
{

  /* USER CODE BEGIN I2C1_Init 0 */

  /* USER CODE END I2C1_Init 0 */

  /* USER CODE BEGIN I2C1_Init 1 */

  /* USER CODE END I2C1_Init 1 */
  hi2c1.Instance = I2C1;
  hi2c1.Init.Timing = 0x2000090E;
  hi2c1.Init.OwnAddress1 = 0;
  hi2c1.Init.AddressingMode = I2C_ADDRESSINGMODE_7BIT;
  hi2c1.Init.DualAddressMode = I2C_DUALADDRESS_DISABLE;
  hi2c1.Init.OwnAddress2 = 0;
  hi2c1.Init.OwnAddress2Masks = I2C_OA2_NOMASK;
  hi2c1.Init.GeneralCallMode = I2C_GENERALCALL_DISABLE;
  hi2c1.Init.NoStretchMode = I2C_NOSTRETCH_DISABLE;
  if (HAL_I2C_Init(&hi2c1) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure Analogue filter
  */
  if (HAL_I2CEx_ConfigAnalogFilter(&hi2c1, I2C_ANALOGFILTER_ENABLE) != HAL_OK)
  {
    Error_Handler();
  }
  /** Configure Digital filter
  */
  if (HAL_I2CEx_ConfigDigitalFilter(&hi2c1, 0) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN I2C1_Init 2 */

  /* USER CODE END I2C1_Init 2 */

}

/**
  * @brief SPI1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_SPI1_Init(void)
{

  /* USER CODE BEGIN SPI1_Init 0 */

  /* USER CODE END SPI1_Init 0 */

  /* USER CODE BEGIN SPI1_Init 1 */

  /* USER CODE END SPI1_Init 1 */
  /* SPI1 parameter configuration*/
  hspi1.Instance = SPI1;
  hspi1.Init.Mode = SPI_MODE_MASTER;
  hspi1.Init.Direction = SPI_DIRECTION_2LINES;
  hspi1.Init.DataSize = SPI_DATASIZE_8BIT;
  hspi1.Init.CLKPolarity = SPI_POLARITY_LOW;
  hspi1.Init.CLKPhase = SPI_PHASE_1EDGE;
  hspi1.Init.NSS = SPI_NSS_SOFT;
  hspi1.Init.BaudRatePrescaler = SPI_BAUDRATEPRESCALER_32;
  hspi1.Init.FirstBit = SPI_FIRSTBIT_MSB;
  hspi1.Init.TIMode = SPI_TIMODE_DISABLE;
  hspi1.Init.CRCCalculation = SPI_CRCCALCULATION_DISABLE;
  hspi1.Init.CRCPolynomial = 7;
  hspi1.Init.CRCLength = SPI_CRC_LENGTH_DATASIZE;
  hspi1.Init.NSSPMode = SPI_NSS_PULSE_DISABLE;
  if (HAL_SPI_Init(&hspi1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN SPI1_Init 2 */

  /* USER CODE END SPI1_Init 2 */

}

/**
  * @brief TIM14 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM14_Init(void)
{

  /* USER CODE BEGIN TIM14_Init 0 */

  /* USER CODE END TIM14_Init 0 */

  TIM_OC_InitTypeDef sConfigOC = {0};

  /* USER CODE BEGIN TIM14_Init 1 */

  /* USER CODE END TIM14_Init 1 */
  htim14.Instance = TIM14;
  htim14.Init.Prescaler = 47;
  htim14.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim14.Init.Period = 19999;
  htim14.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim14.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim14) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim14) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  if (HAL_TIM_PWM_ConfigChannel(&htim14, &sConfigOC, TIM_CHANNEL_1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM14_Init 2 */

  /* USER CODE END TIM14_Init 2 */
  HAL_TIM_MspPostInit(&htim14);

}

/**
  * @brief USART2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART2_UART_Init(void)
{

  /* USER CODE BEGIN USART2_Init 0 */

  /* USER CODE END USART2_Init 0 */

  /* USER CODE BEGIN USART2_Init 1 */

  /* USER CODE END USART2_Init 1 */
  huart2.Instance = USART2;
  huart2.Init.BaudRate = 38400;
  huart2.Init.WordLength = UART_WORDLENGTH_8B;
  huart2.Init.StopBits = UART_STOPBITS_1;
  huart2.Init.Parity = UART_PARITY_NONE;
  huart2.Init.Mode = UART_MODE_TX_RX;
  huart2.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart2.Init.OverSampling = UART_OVERSAMPLING_16;
  huart2.Init.OneBitSampling = UART_ONE_BIT_SAMPLE_DISABLE;
  huart2.AdvancedInit.AdvFeatureInit = UART_ADVFEATURE_NO_INIT;
  if (HAL_UART_Init(&huart2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART2_Init 2 */

  /* USER CODE END USART2_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOF_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOC, IN4_Pin|IN2_Pin|IN3_Pin|IN1_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, LD2_Pin|CAN1_CS_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(CAN2_CS_GPIO_Port, CAN2_CS_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin : B1_Pin */
  GPIO_InitStruct.Pin = B1_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_FALLING;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(B1_GPIO_Port, &GPIO_InitStruct);

  /*Configure GPIO pins : IN4_Pin IN2_Pin IN3_Pin IN1_Pin */
  GPIO_InitStruct.Pin = IN4_Pin|IN2_Pin|IN3_Pin|IN1_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);

  /*Configure GPIO pins : LD2_Pin CAN1_CS_Pin */
  GPIO_InitStruct.Pin = LD2_Pin|CAN1_CS_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pin : CAN2_CS_Pin */
  GPIO_InitStruct.Pin = CAN2_CS_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(CAN2_CS_GPIO_Port, &GPIO_InitStruct);

  /*Configure GPIO pin : ICAN1_Pin */
  GPIO_InitStruct.Pin = ICAN1_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_RISING;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  HAL_GPIO_Init(ICAN1_GPIO_Port, &GPIO_InitStruct);

  /* EXTI interrupt init*/
  HAL_NVIC_SetPriority(EXTI4_15_IRQn, 3, 0);
  HAL_NVIC_EnableIRQ(EXTI4_15_IRQn);

}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart) {
	for (uint8_t i = 0; i < 4; i++) {
		osMessageQueuePut(RX_QueueHandle, &data_RX[i], 0, 0); //Ponemos mensaje recibido en cola byte a byte
	}
	HAL_UART_Receive_IT(&huart2, data_RX, 4); //recibimos siguiente mensaje completo
}
void HAL_ADC_ConvCpltCallback(ADC_HandleTypeDef *hadc) {
	uint16_t adc_value = HAL_ADC_GetValue(hadc);
	osMessageQueuePut(ADC_QueueHandle, &adc_value, 0, 0); //Metemos valor en la cola
	adc_int++; //Incrementamos numero de veces que hemos sacado valor del ADC
	if (adc_int == 2) {
		HAL_ADC_Stop_IT(hadc); //Si no hemos sacado la conversion de los 2 canales no paramos interrupcion
		adc_int = 0; //Reseteamos numero de conversiones
	}
}
void HAL_UART_TxCpltCallback(UART_HandleTypeDef *huart) {
	osSemaphoreRelease(TX_SemHandle);	//Liberamos semaforo TX
}
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin) {
	if (GPIO_Pin == ICAN1_Pin) {
		osSemaphoreRelease(CAN_SemHandle);	//Liberamos semaforo CAN
	}
}
/* USER CODE END 4 */

/* USER CODE BEGIN Header_StartDefaultTask */
/**
 * @brief  Function implementing the defaultTask thread.
 * @param  argument: Not used
 * @retval None
 */
/* USER CODE END Header_StartDefaultTask */
void StartDefaultTask(void *argument)
{
  /* USER CODE BEGIN 5 */
	/* Infinite loop */
	for (;;) {
		HAL_GPIO_TogglePin(LD2_GPIO_Port, LD2_Pin);
		osDelay(led);
	}
  /* USER CODE END 5 */
}

/* USER CODE BEGIN Header_RX_Task */
/**
 * @brief Function implementing the RX_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_RX_Task */
void RX_Task(void *argument)
{
  /* USER CODE BEGIN RX_Task */
	/* USER CODE BEGIN 5 */
	motorPP.velocidad = 0;
	motorPP.direccion = 1;
	motorPP.periodo = 2;
	Servo.espera=2000;
	uint8_t command[4];
	HAL_UART_Receive_IT(&huart2, data_RX, 4);	//Recibimos primer mensaje
	/* Infinite loop */
	for (;;) {
		for (uint8_t i = 0; i < 4; i++) {
			osMessageQueueGet(RX_QueueHandle, &command[i], 0, osWaitForever);//Guardamos byte a byte el mensaje en mensaje
		}
		if (command[3] == 0xE0) {
			switch (command[0]) {
			case 0x41://(A) mandar velocidad y tiempo de espera de servo por mensaje
				Servo.espera = command[1] * 1000;
				Servo.tiempo_ms = (1.0 / command[2]) * 1000;
				Servo.actuacion = 3;
				break;
			case 0x43:	//(C) Parar motor, adc, transmision y servo
				osThreadSuspend(TX_taskHandle);
				osThreadSuspend(OLED_taskHandle);
				osThreadSuspend(TX_TMP_taskHandle);
				osThreadSuspend(ADC_taskHandle);
				osThreadSuspend(SteppingMotor_THandle);
				HAL_GPIO_WritePin(GPIOC,IN1_Pin, 0);
				HAL_GPIO_WritePin(GPIOC,IN2_Pin, 0);
				HAL_GPIO_WritePin(GPIOC,IN3_Pin, 0);
				HAL_GPIO_WritePin(GPIOC,IN4_Pin, 0);
				led=50;//Led parpadea a 50ms
				ssd1306_SetDisplayOn(0);//Apagamos pantalla
				Servo.actuacion = 0;//Ponemos servo en modo off
				remote.CAN_Flag = false;//Desactivamos monitorizacion
				break;
			case 0x44:	//(D) Sentido horario motor paso a paso
				motorPP.direccion = 1;
				osThreadResume(TX_TMP_taskHandle);
				osThreadResume(TX_taskHandle);
				osThreadResume(ADC_taskHandle);
				osThreadResume(SteppingMotor_THandle);
				break;
			case 0x49:	//(I) Sentido antihorario motor paso a paso
				motorPP.direccion = 0;
				osThreadResume(ADC_taskHandle);
				osThreadResume(SteppingMotor_THandle);
				osThreadResume(TX_TMP_taskHandle);
				osThreadResume(TX_taskHandle);
				break;
			case 0x50:	//(P) Funcionamiento servo con potenciometro
				Servo.actuacion = 1;
				osThreadResume(TX_taskHandle);
				osThreadResume(ADC_taskHandle);
				break;
			case 0x52:	//Activacion CAN
				osThreadResume(ADC_taskHandle);
				remote.CAN_Mode = command[1];	//Guardamos modo
				if (remote.CAN_Mode == 0) {	//Modo A
					remote.soyA = true;//Activamos flag A
					remote.soyB = false;
					remote.soyAB = false;
				} else if (remote.CAN_Mode == 1) {	//Modo B
					remote.soyA = false;
					remote.soyB = true;//Flag B
					remote.soyAB = false;
				} else if (remote.CAN_Mode == 2) {	//Modo AB
					remote.soyA = false;
					remote.soyB = false;
					remote.soyAB = true;//Flag AB
				}
				if ((remote.soyA || remote.soyAB)
						&& CANSPI_Initialize(CAN, CAN1_CS_Pin)) {//Mando trama de 0's con la ID 0x22
					CANSPI_CL_Flag_Int(CAN, CAN1_CS_Pin);//Limpiamos bus
					txMessage.frame.idType = dSTANDARD_CAN_MSG_ID_2_0B;
					txMessage.frame.id = 0x22;
					txMessage.frame.dlc = 8;
					txMessage.frame.data0 = 0;
					txMessage.frame.data1 = 0;
					txMessage.frame.data2 = 0;
					txMessage.frame.data3 = 0;
					txMessage.frame.data4 = 0;
					txMessage.frame.data5 = 0;
					txMessage.frame.data6 = 0;
					txMessage.frame.data7 = 0;
					CANSPI_Transmit(CAN, &txMessage, CAN1_CS_Pin);
				}
				if ((remote.soyB || remote.soyAB)
						&& CANSPI_Initialize(CAN, CAN2_CS_Pin)) {//Mando trama de 0's con ID 0x11
					CANSPI_CL_Flag_Int(CAN, CAN2_CS_Pin);
					txMessage.frame.idType = dSTANDARD_CAN_MSG_ID_2_0B;
					txMessage.frame.id = 0x11;
					txMessage.frame.dlc = 8;
					txMessage.frame.data0 = 0;
					txMessage.frame.data1 = 0;
					txMessage.frame.data2 = 0;
					txMessage.frame.data3 = 0;
					txMessage.frame.data4 = 0;
					txMessage.frame.data5 = 0;
					txMessage.frame.data6 = 0;
					txMessage.frame.data7 = 0;
					CANSPI_Transmit(CAN, &txMessage, CAN2_CS_Pin);
				}
				break;
			case 0x53:	//(S) Funcionamiento servo con LKnob
				Servo.actuacion = 2;
				Servo.posicion = command[1];
				osThreadResume(ADC_taskHandle);
				osThreadResume(TX_TMP_taskHandle);
				osThreadResume(TX_taskHandle);
				break;
			case 0x54:	//(T) Comando tiempo para envio de temperatura ADC
				periodoTMP = ((uint16_t) command[1]) * 256 + command[2];
				osThreadResume(ADC_taskHandle);
				osThreadResume(TX_TMP_taskHandle);
				break;
			case 0x58:	//(X) activar pantalla OLED
				osThreadResume(OLED_taskHandle);
				ssd1306_SetDisplayOn(1);	//Encendemos pantalla
				modo_oled = 0;	//Modo visualizacion de datos
				break;
			case 0x60:	//Reanudar tareas
				osThreadResume(TX_TMP_taskHandle);
				osThreadResume(TX_taskHandle);
				osThreadResume(ADC_taskHandle);
				osThreadResume(OLED_taskHandle);
				osThreadResume(SteppingMotor_THandle);
				ssd1306_SetDisplayOn(1);
				break;
			case 0x61:	//Pantalla con calavera
				osThreadResume(OLED_taskHandle);
				ssd1306_SetDisplayOn(1);
				modo_oled = 1;
				break;
			case 0x62:	//Pantalla con Garfield
				osThreadResume(OLED_taskHandle);
				ssd1306_SetDisplayOn(1);
				modo_oled = 2;
				break;
			case 0x63:	//Pantalla con ST
				osThreadResume(OLED_taskHandle);
				ssd1306_SetDisplayOn(1);
				modo_oled = 3;
				break;
			case 0x64:	//Modo EPS
				osThreadResume(OLED_taskHandle);
				ssd1306_SetDisplayOn(1);
				modo_oled = 4;
				break;
			case 0x4D://(M) Comando velocidad motor paso a paso a traves de LKnob
				osThreadResume(SteppingMotor_THandle);
				motorPP.velocidad = command[1];
				motorPP.running = 1;
				if (command[1] != 0) {
					motorPP.periodo = round(1 / (motorPP.velocidad * (2.048 / 60)));
				} else {
					motorPP.periodo = 100;
				}
				break;
			default:
				break;
			}
		}
//		osDelay(1);
	}
  /* USER CODE END RX_Task */
}

/* USER CODE BEGIN Header_ADC_Task */
/**
 * @brief Function implementing the ADC_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_ADC_Task */
void ADC_Task(void *argument)
{
  /* USER CODE BEGIN ADC_Task */
	float adc_in_11_voltage;
	uint16_t adc_value0, adc_value11;
	HAL_ADCEx_Calibration_Start(&hadc);//Calibramos
	/* Infinite loop */
	for (;;) {
		HAL_ADC_Start_IT(&hadc);
		osMessageQueueGet(ADC_QueueHandle, &adc_value0, 0, osWaitForever);//Sacamos conversion potenciometro de la cola
		osMessageQueueGet(ADC_QueueHandle, &adc_value11, 0, osWaitForever);	//Sacamos conversion temperatura
		adc_in_11_voltage = (adc_value11 / 4095.0) * 3300;
		temp = adc_in_11_voltage / 10;
		if (Servo.actuacion == 1) {//Si estamos en modo servo con potenciometro
			Servo.posicion = (adc_value0 / 4095.0) * 90;//actualizamos posicion
		}
		osEventFlagsSet(ADC_EventHandle, EVENT_FLAG_VALUE);//Activamos flag de conversion
		if (remote.CAN_Flag && (remote.soyA || remote.soyAB)) {//Si tenemos monitorizacion activada mandamos info por can
			CANSPI_CL_Flag_Int(CAN, CAN1_CS_Pin);
			txMessage.frame.idType = dSTANDARD_CAN_MSG_ID_2_0B;
			txMessage.frame.id = 0x15;
			txMessage.frame.dlc = 8;
			txMessage.frame.data0 = temp;
			txMessage.frame.data1 = (temp - txMessage.frame.data0) * 100;
			txMessage.frame.data2 = Servo.posicion;
			txMessage.frame.data3 = motorPP.velocidad;
			txMessage.frame.data4 = motorPP.direccion;
			txMessage.frame.data5 = 1;
			txMessage.frame.data6 = 0xC;
			txMessage.frame.data7 = 1;
			CANSPI_Transmit(CAN, &txMessage, CAN1_CS_Pin);
		}
		if (remote.CAN_Flag && (remote.soyB || remote.soyAB)) {
			CANSPI_CL_Flag_Int(CAN, CAN2_CS_Pin);
			txMessage.frame.idType = dSTANDARD_CAN_MSG_ID_2_0B;
			txMessage.frame.id = 0x25;
			txMessage.frame.dlc = 8;
			txMessage.frame.data0 = temp;
			txMessage.frame.data1 = (temp - txMessage.frame.data0) * 100;
			txMessage.frame.data2 = Servo.posicion;
			txMessage.frame.data3 = motorPP.velocidad;
			txMessage.frame.data4 = motorPP.direccion;
			txMessage.frame.data5 = 1;
			txMessage.frame.data6 = 0xC;
			txMessage.frame.data7 = 1;
			CANSPI_Transmit(CAN, &txMessage, CAN2_CS_Pin);
		}
		osDelay(100);
	}
  /* USER CODE END ADC_Task */
}

/* USER CODE BEGIN Header_SteppingMotor_task */
/**
 * @brief Function implementing the SteppingMotor_T thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_SteppingMotor_task */
void SteppingMotor_task(void *argument)
{
  /* USER CODE BEGIN SteppingMotor_task */
	char fase = 1;
	/* Infinite loop */
	for (;;) {
			switch (fase) {
			case 1:
				HAL_GPIO_WritePin(GPIOC, IN1_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN2_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN3_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN4_Pin, 0);
				break;
			case 2:
				HAL_GPIO_WritePin(GPIOC, IN1_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN2_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN3_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN4_Pin, 0);
				break;
			case 3:
				HAL_GPIO_WritePin(GPIOC, IN1_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN2_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN3_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN4_Pin, 1);
				break;
			case 4:
				HAL_GPIO_WritePin(GPIOC, IN1_Pin, 1);
				HAL_GPIO_WritePin(GPIOC, IN2_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN3_Pin, 0);
				HAL_GPIO_WritePin(GPIOC, IN4_Pin, 1);
				break;
			}
			if (motorPP.direccion == 1) {	//D
				fase++;
				if (fase >= 5) {
					fase = 1;
				}
				led = 200;	// Led parpadea a 200ms
			} else if (motorPP.direccion == 0) {	//I
				fase--;
				if (fase <= 0) {
					fase = 4;
				}
				led = 800;	//Led parpadea a 800ms
			}
		osDelay(motorPP.periodo);
	}
  /* USER CODE END SteppingMotor_task */
}

/* USER CODE BEGIN Header_Servo_Task */
/**
 * @brief Function implementing the Servo_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_Servo_Task */
void Servo_Task(void *argument)
{
  /* USER CODE BEGIN Servo_Task */
	Servo.tiempo_ms = 33;
	float t_alto; //[1,2]ms
	uint16_t ccr; //[0,19999] ciclos de reloj
	int estado = 0;
	/* Infinite loop */
	for (;;) {
		if (Servo.actuacion == 1) { //MODO POTENCIOMETRO
			osEventFlagsWait(ADC_EventHandle, EVENT_FLAG_VALUE, osFlagsWaitAny,osWaitForever);//Esperamos a conversion
			t_alto = Servo.posicion / 90.0 + 1;	//Realmente el servo tomara -90º si estamos en 0 grados (1ms) y 90º si son 90 grados (2ms) por lo que el rango son 180º
			ccr = t_alto * 20000.0 / 20.0;//Obtenemos valor CCR con el ARR y el DC
			htim14.Instance->CCR1 = ccr;//Cargamos CCR
			osDelay(100);
		} else if (Servo.actuacion == 2) {	//MODO S (RECEPCION POSICION)
			t_alto = Servo.posicion / 90.0 + 1;
			ccr = t_alto * 20000.0 / 20.0;
			htim14.Instance->CCR1 = ccr;
			Servo.actuacion = 0;//Este comando solo se tiene que ejecutar 1 vez porque recibe por mensaje la posicion
			osDelay(100);
		} else if (Servo.actuacion == 3) { //MODO A (INTRODUCIENDO VELOCIDAD)
			switch (estado) {
			case 0: //Reposo
				Servo.posicion = 0;
				estado = 1;
				osDelay(100);
				break;
			case 1: //Abriendo
				if (Servo.posicion < 90){//de 0 a 89º
					t_alto = Servo.posicion / 90.0 + 1;
					ccr = t_alto / 20.0 * 20000;
					htim14.Instance->CCR1 = ccr;//Cargamos CCR para incrementar servo
					Servo.posicion = Servo.posicion + 1;//Incrementamos posicion
				} else {//90º
					t_alto = Servo.posicion / 90.0 + 1;
					ccr = t_alto / 20.0 * 20000;
					htim14.Instance->CCR1 = ccr;
					estado = 2;
				}
				osDelay(Servo.tiempo_ms);
				break;
			case 2: //Espera
				osDelay(Servo.espera);
				estado = 3;
				break;
			case 3: //Cerrando
				if (Servo.posicion > 0) {
					t_alto = Servo.posicion / 90.0 + 1;
					ccr = t_alto / 20.0 * 20000;
					htim14.Instance->CCR1 = ccr;
					Servo.posicion = Servo.posicion - 1;
				} else {
					t_alto = Servo.posicion / 90.0 + 1;
					ccr = t_alto / 20.0 * 20000;
					htim14.Instance->CCR1 = ccr;
					estado = 0;
					Servo.actuacion = 0;
				}
				osDelay(Servo.tiempo_ms);
				break;
			default:
				osDelay(50);
				break;
			}
		} else
			osDelay(100);
	}
  /* USER CODE END Servo_Task */
}

/* USER CODE BEGIN Header_TX_Task */
/**
 * @brief Function implementing the TX_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_TX_Task */
void TX_Task(void *argument)
{
  /* USER CODE BEGIN TX_Task */
	uint8_t trama[8][4]={
			{0x20,Servo.posicion,0xFF,0xE0},//Trama posicion del servo
			{0x21,remote.servo,0xFF,0xE0},//Trama servo remota
			{0x31,remote.tmp_ent,remote.tmp_dec,0xE0},//Trama temperatura remota
			{0x40,motorPP.velocidad,motorPP.direccion,0xE0},//Trama velocidad motor
			{0x41,remote.rpm,remote.direccion,0xE0},//Trama velocidad remota
	};
  /* Infinite loop */
  for(;;)
  {
	  trama[0][1]=Servo.posicion;//actualizamos tramas
	  trama[1][1]=remote.servo;
	  trama[2][1]=remote.tmp_ent,trama[2][2]=remote.tmp_dec;
	  trama[3][1]=motorPP.velocidad,trama[3][2]=motorPP.direccion;
	  trama[4][1]=remote.rpm,trama[4][2]=remote.direccion;
	  for(uint8_t i=0;i<5;i++){
		  osSemaphoreAcquire(TX_SemHandle, osWaitForever);//Cogemos semaforo
		  HAL_UART_Transmit_IT(&huart2, trama[i], sizeof(trama[i]));//Transmitimos
	  }

	osDelay(100);
  }
  /* USER CODE END TX_Task */
}

/* USER CODE BEGIN Header_TX_TMP_Task */
/**
 * @brief Function implementing the TX_TMP_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_TX_TMP_Task */
void TX_TMP_Task(void *argument)
{
  /* USER CODE BEGIN TX_TMP_Task */
	uint8_t command[4];
	/* Infinite loop */
	for (;;) {
		osEventFlagsWait(ADC_EventHandle, EVENT_FLAG_VALUE, osFlagsWaitAny,osWaitForever);//Esperamos conversion
		command[0] = 0x30;
		command[1] = temp;
		command[2] = (temp - command[1]) * 100;
		command[3] = 0xE0;
		temp_int = command[1];//Guardamos parte entera y decimal de temperatura para pantalla OLED
		temp_decimal = command[2];
		osSemaphoreAcquire(TX_SemHandle, osWaitForever);//Cogemos semaforo
		HAL_UART_Transmit_IT(&huart2, command, 4);//Transmitimos
		osDelay(periodoTMP);
	}
  /* USER CODE END TX_TMP_Task */
}

/* USER CODE BEGIN Header_OLED_Task */
/**
 * @brief Function implementing the OLED_task thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_OLED_Task */
void OLED_Task(void *argument)
{
  /* USER CODE BEGIN OLED_Task */
//Direccion I2C son 7 bits 6+bit SA0 (Slave Address que puede ser 1 o 0)
//Segun datasheet puede ser 0111100 o 0111101, lsb es el SA0 bit
	uint16_t i2c_dir0 = 0x3C << 1; //Comprobado que es la direccion con el SA0 puesto a 0 (0111100)
  //uint16_t i2c_dir1=0x3D << 1;
	char msg[20];//String mostrado en pantalla
	char sentido;//Sentido de giro de motor
	/* Infinite loop */
	for (;;) {
		if (HAL_I2C_IsDeviceReady(&hi2c1, i2c_dir0, 3, 1000) == HAL_OK) {//Si direccion es correcta
			uint8_t y = 0; //Coordenada vertical a 0 para empezar desde arriba
			switch (modo_oled) {
			case 0:	//Modo visualizacion de datos
				sprintf(msg, "Servo: %i", (uint8_t) Servo.posicion);//Escribimos string
				ssd1306_Fill(Black);	//Pantalla a negro
				ssd1306_SetCursor(2, y);//Apuntamos al pixel mapeado en (2,0)
				ssd1306_WriteString(msg, Font_11x18, White);//Escribimos string en pantalla
				y += 20;//Incrementamos puntero vertical 18 pixeles(altura de letra)+ 2 pixeles extra
				sprintf(msg, "Temp=%i.%i", temp_int, temp_decimal);//String temperatura
				ssd1306_SetCursor(2, y);
				ssd1306_WriteString(msg, Font_11x18, White);
				y += 20;
				if (motorPP.direccion == 0) {//Segun direccion de giro de motor asociamos sentido a una letra u otra
					sentido = 'I';//Izquierda
				} else {//1
					sentido = 'D';//Derecha
				}
				sprintf(msg, "Motor:%d,%c", motorPP.velocidad, sentido);//String motor
				ssd1306_SetCursor(2, y);
				ssd1306_WriteString(msg, Font_11x18, White);
				ssd1306_UpdateScreen();	//Una vez escrito todo en pantalla, actualizamos
				break;
			case 1:	//Modo dibujar calavera
				ssd1306_DrawSkull();
				break;
			case 2: //Modo dibujar Garfield
				ssd1306_DrawGarfield();
				break;
			case 3: //Modo dibujar logo ST
				ssd1306_DrawST();
				break;
			case 4://Modo logo EPS
				ssd1306_DrawEPS();
				break;
			default:
				break;
			}
		}
		osDelay(250);
	}
  /* USER CODE END OLED_Task */
}

/* USER CODE BEGIN Header_CAN_remote_task */
/**
 * @brief Function implementing the CAN_remote thread.
 * @param argument: Not used
 * @retval None
 */
/* USER CODE END Header_CAN_remote_task */
void CAN_remote_task(void *argument)
{
  /* USER CODE BEGIN CAN_remote_task */

	/* Infinite loop */
	for (;;) {
		osSemaphoreAcquire(CAN_SemHandle, osWaitForever);//Cogemos semaforo
		if (CANSPI_Receive(CAN, &rxMessage, CAN1_CS_Pin)) {//Si hemos recibido en el CAN1...
			if (rxMessage.frame.id == 0x11 && rxMessage.frame.dlc == 8
					&& rxMessage.frame.data0 == 0 && rxMessage.frame.data1 == 0
					&& rxMessage.frame.data2 == 0 && rxMessage.frame.data3 == 0
					&& rxMessage.frame.data4 == 0 && rxMessage.frame.data5 == 0
					&& rxMessage.frame.data6 == 0
					&& rxMessage.frame.data7 == 0) {
				remote.CAN_Flag = true;//Si se han recibido 8 bytes a 0 en la id 0x11 activamos monitorizacion
			}else if (rxMessage.frame.id == 0x25 && rxMessage.frame.dlc == 8
					&& rxMessage.frame.data5 == 1
					&& rxMessage.frame.data6 == 0xC
					&& rxMessage.frame.data7 == 1) {//Si en cambio se han recibido 8 bytes en la 0x25, actualizamos
				remote.tmp_ent = rxMessage.frame.data0;
				remote.tmp_dec = rxMessage.frame.data1;
				remote.servo = rxMessage.frame.data2;
				remote.rpm = rxMessage.frame.data3;
				remote.direccion = rxMessage.frame.data4;
			}
			CANSPI_CL_Flag_Int(CAN, CAN1_CS_Pin);//Limpiamos bus
		} else if (CANSPI_Receive(CAN, &rxMessage, CAN2_CS_Pin)) {//Lo mismo para CAN_2
			if (rxMessage.frame.id == 0x22 && rxMessage.frame.dlc == 8
					&& rxMessage.frame.data0 == 0 && rxMessage.frame.data1 == 0
					&& rxMessage.frame.data2 == 0 && rxMessage.frame.data3 == 0
					&& rxMessage.frame.data4 == 0 && rxMessage.frame.data5 == 0
					&& rxMessage.frame.data6 == 0
					&& rxMessage.frame.data7 == 0) {
				remote.CAN_Flag = true;
			}else if (rxMessage.frame.id == 0x15 && rxMessage.frame.dlc == 8
					&& rxMessage.frame.data5 == 1
					&& rxMessage.frame.data6 == 0xC
					&& rxMessage.frame.data7 == 1) {
				remote.tmp_ent = rxMessage.frame.data0;
				remote.tmp_dec = rxMessage.frame.data1;
				remote.servo = rxMessage.frame.data2;
				remote.rpm = rxMessage.frame.data3;
				remote.direccion = rxMessage.frame.data4;
			}
			CANSPI_CL_Flag_Int(CAN, CAN2_CS_Pin);
		}
		osDelay(500);
	}
  /* USER CODE END CAN_remote_task */
}

 /**
  * @brief  Period elapsed callback in non blocking mode
  * @note   This function is called  when TIM1 interrupt took place, inside
  * HAL_TIM_IRQHandler(). It makes a direct call to HAL_IncTick() to increment
  * a global variable "uwTick" used as application time base.
  * @param  htim : TIM handle
  * @retval None
  */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
  /* USER CODE BEGIN Callback 0 */

  /* USER CODE END Callback 0 */
  if (htim->Instance == TIM1) {
    HAL_IncTick();
  }
  /* USER CODE BEGIN Callback 1 */

  /* USER CODE END Callback 1 */
}

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
	/* User can add his own implementation to report the HAL error return state */
	__disable_irq();
	while (1) {
	}
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
