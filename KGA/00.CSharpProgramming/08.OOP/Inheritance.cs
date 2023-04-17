using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.OOP
{
    /*
     * 상속 (Inheritance)
     * 부모 클래스의 모든 기능을 가지는 자식 클래스를 설계하는 방법
     * is-a 관계: 부모 클래스와 자식 클래스를 포함하는 상위 개념일 경우 상속 관계가 적합함
     */

    // 오크: 체력, 방어력, 공격력, 때리기, 맞기, 드랍아이템A
    // 고블린: 체력, 방어력, 공격력, 때리기, 맞기, 도망치기, 드랍아이템B
    // =>
    // 몬스터: 체력, 방어력, 공격력, 때리기, 맞기
    // 오크(몬스터 상속): 드랍아이템A
    // 고블린(몬스터 상속): 도망치기, 드랍아이템B
    // =>
    // 몬스터: 체력, 방어력, 공격력, 때리기, 맞기
    // 오크(몬스터 상속): 드랍아이템A
    // 오크 대장(오크 상속): 오크 소환
    // 고블린(몬스터 상속): 도망치기, 드랍아이템B

    public class Person
    {
        protected string name;

        public Person(string _name)
        {
            name = _name;
        }

        public string GetName()
        {
            return name;
        }
    }

    public class Student : Person
    {
        private int id;

        public Student(string _name, int _id) : base(_name)
        {
            id = _id;
        }

        public int GetId()
        {
            return id;
        }
    }

    public class Worker : Person
    {
        public Worker(string _name) : base(_name)
        { 

        }

        public void ReName(string _name)
        {
            name = _name;
        }
    }

    internal class Inheritance
    {
        public static void Test()
        {
            Person person = new Person("Kim");
            Student student = new Student("Lee", 1);
            Worker worker = new Worker("Park");

            // 부모클래스 Person을 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
            person.GetName();
            student.GetName();
            worker.GetName();

            // 자식클래스는 부모클래스의 기능에 자식만의 기능을 더욱 추가하여 구현 가능
            student.GetId();
            worker.ReName("Paik");

            // 부모클래스에 자식 인스턴스를 담아둘 수 있음
            Person studentInPerson = new Student("Choi", 2);
            Person workerInPerson = new Worker("Jung");

            // 자식클래스의 기능을 사용하고 싶다면 다시 자식클래스에 담아서 사용가능
            Student castStudent = (Student)studentInPerson;
            castStudent.GetId();

            // 부모클래스에 담겨있는 자식 인스턴스가 자식클래스로 다시 자식클래스에 담는 것을 정적형변환으로 할 경우 위험할 수 있음
            // 담겨있던 인스턴스가 형변환이 불가한 경우 예외 발생
            // Student castFail = (Student)workerInPerson;		// error : 담겨있던 인스턴스가 형변환이 불가함

            // is : 담겨있는 인스턴스가 형변환이 가능한지 확인
            if (studentInPerson is Student)
            {
                Console.WriteLine("{0} 인스턴스는 Student로 형변환 가능");
                Student cast = (Student)studentInPerson;
            }
            else
            {
                Console.WriteLine("{0} 인스턴스는 Student로 형변환 불가");
            }

            if (studentInPerson is Worker)
            {
                Console.WriteLine("{0} 인스턴스는 Worker로 형변환 가능");
                Worker cast = (Worker)studentInPerson;
            }
            else
            {
                Console.WriteLine("{0} 인스턴스는 Worker로 형변환 불가");
            }

            // as : 담겨있는 인스턴스가 형변환이 가능하다면 형변환 결과를 불가하다면 null을 반환
            Student asStudent = studentInPerson as Student;     // 형변환
            Worker asWorker = studentInPerson as Worker;        // null 반환
        }
    }
}
