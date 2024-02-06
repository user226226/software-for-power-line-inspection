import React, { useState } from 'react';
// import { useHistory } from 'react-router-dom';
import styles from "./SideBar.module.css";
import MapPinIcon from "./MapPinIcon";
import Map from "./Map";
import ArrowLeftIcon from './ArrowLeftIcon';

const SideBar = () => {
  const [selectedCoordinate, setSelectedCoordinate] = useState(null);
  const [eventDb, setEventDb] = useState(null);

  const handleMarkerClick = (point) => {
    async function fetchData() {
      try {
        const result = await fetch("https://localhost:7001/GetEventByCoor", {
          method: 'POST',
          headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(point)
        });
        const data = await result.json();
        setEventDb(data)
        console.log(data);
      } catch (error) {
        alert("В данный момент сервер выключен")
        console.error(error);
      }
    }
    fetchData();
    setSelectedCoordinate(point);
  };

  const [file, setFile] = useState(null);

  const handleFileChange = (e) => {
    if (e.target.files) {
      setFile(e.target.files[0]);
    }
  };

  const handleUpload = async () => {
    if (file) {
      console.log("Uploading file...");

      const formData = new FormData();
      formData.append("uploadedFile", file);
      console.log(file)

      try {
        const result = await fetch("https://localhost:7001/Event", {
          method: "POST",
          body: formData,
        });

        const data = await result.json();

        console.log(data);
      } catch (error) {
        console.error(error);
      }
    }

  // const history = useHistory();
  
  // const goBack = () => {
  //   history.goBack(); // Используйте этот метод для перехода назад
  // };

  };

  return (
    <>
      <div className={styles.containerSideBar}>
        {/* Боковое меню */}
        <div className={styles.sidebaropened}>
          {selectedCoordinate && eventDb ? (
            <>
              <button className={styles.buttonBack}>
                  <ArrowLeftIcon className={styles.arrowBack}/>
                  <span>Назад</span>
              </button>
              <b className={styles.b}>Сведения о повреждении</b>

              {/* Фото повреждения */}
              <img className={styles.icon} alt="" src="/@2x.png" />

              {/* Координаты */}
              <div className={styles.mapPinIcon}><MapPinIcon/></div>
              <div className={styles.div}>
                <div className={styles.div1}>{selectedCoordinate.coordinates[0]}°</div>
                <div className={styles.div2}>{selectedCoordinate.coordinates[1]}°</div>
              </div>

              {/* Полная информация */}
              <div className={styles.div7}>Текущее состояние</div>
              <div className={styles.example4}>{
                eventDb.statusEvent?eventDb.statusEvent.name:"Нет данных"
              }</div>
              <div className={styles.div6}>Характер повреждения</div>
              <div className={styles.example3}>{
                eventDb.typeEvent?eventDb.typeEvent.name:"Нет данных"
              }</div>
              <div className={styles.div8}>Дата обследования</div>
              <div className={styles.example5}>{
                eventDb.dateCreate?eventDb.dateCreate:"Нет данных"
              }</div>
              <div className={styles.line1}></div>
              <div className={styles.div5}>Дрон</div>
              <div className={styles.example2}>{
                eventDb.dron?eventDb.dron.name:"Нет данных"
              }</div>
              <div className={styles.div4}>Полезная нагрузка</div>
              <div className={styles.example1}>{
                eventDb.dron.pNagruzka?
                    eventDb.dron.pNagruzka.name
                    :"Нет данных"}</div>
              <div className={styles.line2}></div>
              <div className={styles.div3}>Бригада</div>
              <div className={styles.example}>{
                eventDb.crew?
                    eventDb.crew.name
                    :"Нет данных"}</div>
              <div className={styles.line3}></div>
            </>
          ) : (
            <>
              <div className={styles.b2}>
                Выберите Точку<br/>
                Или<br/>
                Загрузите Фото
              </div>
              <div className={styles.fileUpload}>
                <input type="file" onChange={handleFileChange} className={styles.fileInput} />
                <button className={styles.button} onClick={handleUpload}>Загрузить</button>
              </div>
            </>
          )}
        </div>

        {/* Карта */}
        <div className={styles.map}>
          <Map onMarkerClick={handleMarkerClick} />
        </div>
        
      </div>
    </>
  );
};

export default SideBar;

