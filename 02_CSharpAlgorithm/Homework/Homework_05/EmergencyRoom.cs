namespace Homework_05
{
    /// <summary>
    /// 문제 0.
    /// 응급실 만들기
    /// </summary>
    internal class EmergencyRoom
    {
        PriorityQueue<string, int> patients;   // 환자 번호, 골든타임

        public EmergencyRoom()
        {
            patients = new PriorityQueue<string, int>();

            PatientsIn();
            StartAid();
        }

        public void PatientsIn()
        {
            patients.Enqueue("0000", 10);
            patients.Enqueue("0001", 1);
            patients.Enqueue("0002", 9);
            patients.Enqueue("0003", 2);
            patients.Enqueue("0004", 8);
            patients.Enqueue("0005", 3);
            patients.Enqueue("0006", 7);
            patients.Enqueue("0007", 4);
            patients.Enqueue("0008", 6);
            patients.Enqueue("0009", 5);
            patients.Enqueue("0010", 1);
        }

        public void StartAid()
        {
            int time = 0;
            while(patients.COUNT > 0)
            {
                string patientID;
                int goldenTime;

                if(patients.TryDequeue(out patientID, out goldenTime))
                    Console.WriteLine($"ID : {patientID} / 골든타임 : {goldenTime} / 소모시간 : {time}");
                time++;
            }
        }
    }
}
