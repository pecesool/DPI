using System;

namespace DPI
{
    public class Animation
    {
        public string ID { get; set; }//объявление переменных

        public float Value;

        public float StartValue;

        private float targetValue;
        public float TargetValue
        {
            get => targetValue;
            set
            {
                targetValue = value;
                Reverse = value < Value ? true : false;
            }
        }

        public float Volume;

        public bool Reverse = false;

        public AnimationStatus Status { get; set; }
        public enum AnimationStatus//определение статусов анимации
        {
            Requested,
            Active,
            Completed
        }
        int frame = 0;
        private float p15, p30, p70, p85;

        public int StepDivider = 11;

        private float Step()
        {
            float basicStep = Math.Abs(Volume) / StepDivider; // Math.Abs - превращает числа 0< в >0
            float resultStep = 0;
            float updation;
            if(Reverse == false)
            {
                if(Value <= p15 || Value >= p85)
                {
                    resultStep = basicStep / 3.5f;//определение частоты
                    if (frame > 0)
                    {
                        updation = Step();//обновление функции
                    }
                }
                else if (Value <= p30 || Value >= p70)
                {
                    resultStep = basicStep / 2f;
                    if (frame > 0)
                    {
                        updation = Step();
                    }
                }
                else if(Value > p30 && Value < p70)
                {
                    resultStep = basicStep;
                    if (frame > 0)
                    {
                        updation = Step();
                    }
                }
            }
            else
            {
                if (Value >= p15 || Value <= p85)
                {
                    resultStep = basicStep / 3.5f;
                }
                else if (Value >= p30 || Value <= p70)
                {
                    resultStep = basicStep / 2f;
                }
                else if (Value < p30 && Value > p70)
                {
                    resultStep = basicStep;
                }
            }

            return Math.Abs(resultStep);
        }

        private float ValueByPercent(float Percent)
        {
            float COEFF = Percent / 100;//перевод диапозона в проценты
            float VolumeInPercent = Volume * COEFF;
            float ValueInPercent = StartValue + VolumeInPercent;

            return ValueInPercent;
        }

        public delegate void ControlMethod();
        private ControlMethod InvalidateControl;

        public void UpdateFrame()//функция обновления фрейма
        {
            Status = AnimationStatus.Active;

            if (Reverse == false)
            {
                if(Value <= targetValue)
                {
                    Value += Step();

                    if(Value >= targetValue)
                    {
                        Value = targetValue;
                        Status = AnimationStatus.Completed;
                    }
                }
            }
            else
            {
                if (Value >= targetValue)
                {
                    Value -= Step();

                    if (Value <= targetValue)
                    {
                        Value = targetValue;
                        Status = AnimationStatus.Completed;
                    }
                }
            }

            InvalidateControl.Invoke();
        }

        public Animation() { }

        public Animation(string ID, ControlMethod InvalidateControl, float Value, float TargetValue)//объявление публичного класса для использования в других компонентах
        {
            this.ID = ID;

            this.InvalidateControl = InvalidateControl;

            this.Value = Value;
            this.TargetValue = TargetValue;

            StartValue = Value;
            Volume = TargetValue - Value;

            p15 = ValueByPercent(15);
            p30 = ValueByPercent(30);
            p70 = ValueByPercent(70);
            p85 = ValueByPercent(85);
        }
    }
}
